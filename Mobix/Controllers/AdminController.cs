using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Mobix.Data;
using Mobix.ViewModels;
using MobixWebShop.EntityModels;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace Mobix.Controllers
{
    [ApiController]
    [Route("api")]
    public class AdminController : ControllerBase
    {
        private readonly MobixDbContext _db;
        private readonly IWebHostEnvironment _environment;

        public AdminController(MobixDbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }

        [HttpGet("get-all-products")]
        public ActionResult<List<Proizvod>> GetAllProducts()
        {
            var data = _db.Proizvodi.OrderByDescending(p => p.ProizvodID).AsQueryable();
            return data.ToList();
        }


        [HttpPut("edit-proizvod/{id}")]
        public IActionResult EditProizvod(int id, [FromForm] ProizvodVM podaci)
        {
            var odabraniProizvod = _db.Proizvodi.FirstOrDefault(pronadjeni => pronadjeni.ProizvodID == id);
            if (odabraniProizvod == null)
                return BadRequest("Proizvod sa tim IDom ne postoji");
            else
            {
                if (!string.IsNullOrEmpty(podaci.Naziv))
                    odabraniProizvod.Naziv = podaci.Naziv;

                if (podaci.DobavljacProizvodaID != null)
                    odabraniProizvod.DobavljacProizvodaID = podaci.DobavljacProizvodaID;

                if (podaci.Cijena != null)
                    odabraniProizvod.Cijena = podaci.Cijena;

                if (!string.IsNullOrEmpty(podaci.Opis))
                    odabraniProizvod.Opis = podaci.Opis;

                if (podaci.Kolicina != null)
                    odabraniProizvod.Kolicina = podaci.Kolicina;

                if (!string.IsNullOrEmpty(podaci.Stanje))
                    odabraniProizvod.Stanje = podaci.Stanje;

                if (podaci.SlikaFile != null)
                {
                    string ext = Path.GetExtension(podaci.SlikaFile.FileName);
                    string filename = $"{Guid.NewGuid()}{ext}";
                    string folder = "wwwroot/Images/";

                    using (var stream = new FileStream(Path.Combine(folder, filename), FileMode.Create))
                    {
                        podaci.SlikaFile.CopyTo(stream);
                    }

                    if (odabraniProizvod.SlikaProizvoda != null)
                    {
                        string currImagePath = Path.Combine(folder, odabraniProizvod.SlikaProizvoda);
                        System.IO.File.Delete(currImagePath);
                    }

                    odabraniProizvod.SlikaProizvoda = filename;
                }

                _db.Update(odabraniProizvod);
                _db.SaveChanges();
            }
            return Ok(odabraniProizvod);

        }

        [HttpGet("{id}")]
        public ActionResult GetProduct(int id)
        {
            return Ok(_db.Proizvodi.FirstOrDefault(p => p.ProizvodID == id));
        }

        [EnableCors("AllowAnyOriginPolicy")]
        [HttpPost("add-product")]
        //[Authorize]
        public async Task<IActionResult> AddProduct([FromForm] ProizvodVM vm)
        {
          
            var p = new Proizvod
                {
                    Naziv = vm.Naziv,
                    Opis = vm.Opis,
                    Stanje = vm.Stanje,
                    Cijena = vm.Cijena,
                    Kolicina = vm.Kolicina,
                    DobavljacProizvodaID = vm.DobavljacProizvodaID,
                };
            if (vm.SlikaFile != null)
            {
                string ext = Path.GetExtension(vm.SlikaFile.FileName);
                string ContentType = vm.SlikaFile.ContentType;

                var filename = $"{Guid.NewGuid()}{ext}";
                string folder = "wwwroot/Images/";
                vm.SlikaFile.CopyTo(new FileStream(folder + filename, FileMode.Create));
                string currDir = System.IO.Directory.GetCurrentDirectory();
                if (p.SlikaProizvoda != null)
                {
                    System.IO.File.Delete(currDir + "/wwwroot/Images/" + p.SlikaProizvoda);
                }
                p.SlikaProizvoda = filename;
            }
            _db.Add(p);

            await _db.SaveChangesAsync();
  

            return Ok(p);
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
