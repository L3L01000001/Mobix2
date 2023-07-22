using Microsoft.AspNetCore.Mvc;
using Mobix.Data;
using Mobix.EntityModels;
using MobixWebShop.EntityModels;

namespace Mobix.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly MobixDbContext _db;

        public SearchController(MobixDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<List<Proizvod>> SearchProizvod(string proizvodSearch)
        {
            var prozivodi = _db.Proizvodi
                .Where(p => proizvodSearch == null || (p.Naziv).StartsWith(proizvodSearch))
                .OrderByDescending(p => p.ProizvodID)
                .AsQueryable();
            return prozivodi.ToList();
        }
        [HttpGet("korisnik")]
        public ActionResult<List<Korisnik>> SearchKorisnik(string korisnikSearch)
        {
            var korisnici = _db.Users
                .Where(p => korisnikSearch == null || (p.Ime).StartsWith(korisnikSearch)
                || (p.Prezime).StartsWith(korisnikSearch)
                || (p.UserName).StartsWith(korisnikSearch))
                .OrderByDescending(p => p.Id)
                .AsQueryable();
            return korisnici.ToList();
        }
    }
}
