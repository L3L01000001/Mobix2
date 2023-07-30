using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Mobix.Data;
using Mobix.ViewModels;
using MobixWebShop.EntityModels;
using System.Collections.Generic;

namespace Mobix.Controllers
{
    [ApiController]
    [Route("api")]
    public class AdminController : ControllerBase
    {
        private readonly MobixDbContext _db;

        public AdminController(MobixDbContext db)
        {
            _db = db;
        }

        [HttpGet("get-all-products")]
        public ActionResult<List<Proizvod>> GetAllProducts()
        {
            var data = _db.Proizvodi.OrderByDescending(p => p.ProizvodID).AsQueryable();
            return data.ToList();
        }


        [HttpPut("edit-proizvod/{id}")]
        public IActionResult EditProizvod(int id, ProizvodVM podaci)
        {
            var odabraniProizvod = _db.Proizvodi.FirstOrDefault(pronadjeni => pronadjeni.ProizvodID == id);
            if (odabraniProizvod == null)
                return BadRequest("Proizvod sa tim IDom ne postoji");
            else
            {
                odabraniProizvod.Naziv = podaci.Naziv;
                odabraniProizvod.SlikaProizvoda = podaci.Slika;
                odabraniProizvod.DobavljacProizvodaID = podaci.DobavljacProizvodaID;
                odabraniProizvod.Cijena = podaci.Cijena;
                odabraniProizvod.Opis = podaci.Opis;
                odabraniProizvod.Kolicina = podaci.Kolicina;
                odabraniProizvod.Stanje = podaci.Stanje;


                _db.Update(odabraniProizvod);
                _db.SaveChanges();
            }



            return Ok("Uspješno spašen " + odabraniProizvod);

        }

        [HttpGet("{id}")]
        public ActionResult GetProduct(int id)
        {
            return Ok(_db.Proizvodi.FirstOrDefault(p => p.ProizvodID == id));
        }

        [EnableCors("AllowOrigin")]
        [HttpPost("add-product")]
        //[Authorize]
        public ActionResult<Proizvod> AddProduct(ProizvodVM vm)
        {
            var p = new Proizvod
            {
                Naziv = vm.Naziv,
                Opis = vm.Opis,
                Stanje = vm.Stanje,
                Cijena = vm.Cijena,
                SlikaProizvoda = vm.Slika,
                Kolicina = vm.Kolicina,
                DobavljacProizvodaID = vm.DobavljacProizvodaID,
            };
            _db.Add(p);

            _db.SaveChanges();

            return p;
        }

        [HttpDelete("delete/{id}")]
        //[Authorize]
        public IActionResult DeleteProduct(int id)
        {
            var p = _db.Proizvodi.FirstOrDefault(x => x.ProizvodID == id);

            if (p == null)
                return BadRequest("Pogrešan ID");

            _db.Remove(p);
            _db.SaveChanges();

            return Ok();
        }

    }
}
