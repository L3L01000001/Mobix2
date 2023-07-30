using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobix.Data;
using Mobix.EntityModels;
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
        public IActionResult Get(int korisnikId)
        {
            var korpa = _db.Korpa
                .Include(k => k.KorpaStavke)
                .ThenInclude(p => p.Proizvod)
                .FirstOrDefault(k => k.KorisnikId == korisnikId);

            if (korpa == null)
            {
                return BadRequest("Korpa je trenutno prazna.");
            }

            korpa.KorpaStavke.ForEach(ks => ks.Korpa = null);


            return Ok(korpa);
        }

        [HttpPost("dodaj")]
        public IActionResult DodajUKorpu(int korisnikID, int proizvodID, int kolicina)
        {
            var korpa = _db.Korpa.Include(k => k.KorpaStavke).FirstOrDefault(k => k.KorisnikId == korisnikID);

            if (korpa == null)
            {
                korpa = new Korpa { KorisnikId = korisnikID };
                _db.Korpa.Add(korpa);
            }

            var korpaStavka = new KorpaStavke
            {
                Korpa = korpa,
                ProizvodID = proizvodID,
                Kolicina = kolicina
            };
            _db.KorpaStavke.Add(korpaStavka);

            _db.SaveChanges();

            return Ok();
        }

        [HttpPut("{korpaStavkaId}")]
        public ActionResult izmijeni(int korpaStavkaId, int kolicina)
        {
            var korpaStavka = _db.KorpaStavke.FirstOrDefault(ks => ks.ID == korpaStavkaId);

            if (korpaStavka == null)
            {
                return BadRequest("Stavku nije moguce prikazati.");
            };

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

            _db.KorpaStavke.Remove(korpaStavka);
            _db.SaveChanges();

            return Ok();
        }

        //[HttpDelete("{korpaId}")]
        //public ActionResult obrisi(int korpaStavkaId)
        //{
        //    var korpaStavka = _db.Korpa.FirstOrDefault(ks => ks.ID == korpaStavkaId);

        //    if (korpaStavka == null)
        //    {
        //        return BadRequest("Stavka ne postoji.");
        //    };

        //    _db.Korpa.Remove(korpaStavka);
        //    _db.SaveChanges();

        //    return Ok();
        //}
    }
}
