using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobix.Data;
using Mobix.EntityModels;
using Mobix.Migrations;
using System.Security.Claims;

namespace Mobix.Controllers
{
    [ApiController]
    [Route("api")]
    public class CartController : ControllerBase
    {
        private readonly MobixDbContext _db;

        public CartController(MobixDbContext db)
        {
            _db = db;
        }

        [HttpGet("cart")]
        public IActionResult Get(string korisnikId)
        {
            var korpa = _db.Korpa
                .Include(k => k.KorpaStavke)
                .ThenInclude(p => p.Proizvod)
                .FirstOrDefault(k => k.KorisnikId == korisnikId);

            if (korpa == null)
            {
                return new BadRequestObjectResult(new { Message = "Korpa je prazna!" });
            }

            korpa.KorpaStavke.ForEach(ks => ks.Korpa = null);


            return Ok(new
            {
                Korpa = korpa,
                KorpaStavke = korpa.KorpaStavke
            });
        }

        [HttpPost("dodaj")]
        public IActionResult DodajUKorpu(string korisnikID, int proizvodID)
        {
            var korpa = _db.Korpa.Include(k => k.KorpaStavke).FirstOrDefault(k => k.KorisnikId == korisnikID);

            if (korpa == null)
            {
                korpa = new Korpa { KorisnikId = korisnikID };
                _db.Korpa.Add(korpa);
            }

            var postojecaKorpaStavka = korpa.KorpaStavke.FirstOrDefault(ks => ks.ProizvodID == proizvodID);
            var proizvod = _db.Proizvodi.FirstOrDefault(p => p.ProizvodID == proizvodID);

            if (postojecaKorpaStavka != null)
            {
                if(postojecaKorpaStavka.Kolicina < proizvod.Kolicina) { 
                    postojecaKorpaStavka.Kolicina++;
                    _db.KorpaStavke.Update(postojecaKorpaStavka);
                } else
                {
                    return BadRequest("Nedovoljna kolicina proizvoda na stanju.");
                }
            }
            else
            {
                var korpaStavka = new KorpaStavke
                {
                    Korpa = korpa,
                    ProizvodID = proizvodID,
                    Kolicina = 1
                };
                _db.KorpaStavke.Add(korpaStavka);
            }

            _db.SaveChanges();

            var totalKolicina = korpa.KorpaStavke.Sum(ks => ks.Kolicina);

            return Ok(totalKolicina);
        }

        [HttpPut("updateKolicinu/{korpaStavkaId}")]
        public ActionResult updateKolicinu(int korpaStavkaId, int kolicina)
        {
            var korpaStavka = _db.KorpaStavke
                .Include(ks => ks.Proizvod)
                .FirstOrDefault(ks => ks.ID == korpaStavkaId);

            if (korpaStavka == null)
            {
                return BadRequest("Stavku nije moguce prikazati.");
            };

            var proizvod = korpaStavka.Proizvod;
            if(proizvod == null)
            {
                return BadRequest("Proizvod nije pronadjen.");
            }
            if(kolicina > proizvod.Kolicina)
            {
                return BadRequest("Nema dovoljno proizvoda na stanju.");
            }
            korpaStavka.Kolicina = kolicina;
            _db.SaveChanges();

            return Ok();
        }

        [HttpDelete("obrisiStavku/{korpaStavkaId}")]
        public ActionResult obrisiStavku(int korpaStavkaId)
        {
            var korpaStavka = _db.KorpaStavke.FirstOrDefault(ks => ks.ID == korpaStavkaId);

            if (korpaStavka == null)
            {
                return BadRequest("Stavka ne postoji.");
            };

            var korpa = _db.Korpa.Include(k => k.KorpaStavke).FirstOrDefault(k => k.ID == korpaStavka.KorpaId);

            if (korpa == null)
            {
                return BadRequest("Korpa ne postoji.");
            }

            _db.KorpaStavke.Remove(korpaStavka);

            
            _db.SaveChanges();

            var trenutnaKolicina = korpa.KorpaStavke.Sum(ks => ks.Kolicina);
            return Ok(trenutnaKolicina);
        }
    }
}
