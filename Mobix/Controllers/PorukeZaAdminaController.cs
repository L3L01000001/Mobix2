using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobix.Data;
using Mobix.EntityModels;

namespace Mobix.Controllers
{
    [Route("api/messages")]
    [ApiController]
    public class PorukeZaAdminaController : Controller
    {
        private readonly MobixDbContext _db;
        public PorukeZaAdminaController(MobixDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetPoruke()
        {
            var poruke = await _db.PorukeZaAdmina
                .Select(m => m.Sadrzaj)
                .ToListAsync();

            return Ok(poruke);
        }
    }
}
