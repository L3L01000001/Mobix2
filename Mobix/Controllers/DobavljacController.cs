using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Mobix.Data;
using Mobix.EntityModels;
using Mobix.ViewModels;
using MobixWebShop.EntityModels;

namespace Mobix.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DobavljacController : ControllerBase
    {
        private readonly MobixDbContext _db;

        public DobavljacController(MobixDbContext db)
        {
            _db = db;
        }

        [HttpGet("get-all-dobavljaci")]
        public ActionResult<List<Dobavljac>> GetAllDobavljaci()
        {
            var data = _db.Dobavljaci.OrderBy(p => p.DobavljacID).AsQueryable();
            return data.ToList();
        }

        [EnableCors("AllowOrigin")]
        [HttpPost("add-dobavljac")]
        public ActionResult<Dobavljac> AddDobavljac(DobavljacVM vm)
        {
            var p = new Dobavljac
            {
                Naziv = vm.Naziv,
                BrojTelefona = vm.BrojTelefona,
                Adresa=vm.Adresa
            };
            _db.Add(p);

            _db.SaveChanges();

            return p;
        }
    }
}
