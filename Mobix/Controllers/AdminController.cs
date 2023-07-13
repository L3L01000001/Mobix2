using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobix.Data;
using Mobix.ViewModels;
using MobixWebShop.EntityModels;

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

        [HttpGet("{id}")]
        public ActionResult GetProduct(int id)
        {
            return Ok(_db.Proizvodi.FirstOrDefault(p => p.ProizvodID == id));
        }

        [EnableCors("AllowOrigin")]
        [HttpPost("add-product")]
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

        [HttpPost("{id}")]
        public ActionResult DeleteProduct(int ID)
        {
            Proizvod p = _db.Proizvodi.Find(ID);

            if (p == null || ID == 1)
                return BadRequest("Pogrešan ID");

            _db.Remove(p);
            _db.SaveChanges();

            return Ok();
        }

    }
}
