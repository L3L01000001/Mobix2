using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Mobix.Data;
using Mobix.EntityModels;
using Mobix.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;

namespace Mobix.Controllers
{
    [ApiController]
    //[Route("api")]
    public class KorisnikController : ControllerBase
    {
        private readonly MobixDbContext _db;
        PasswordHasher<Korisnik> hasher = new PasswordHasher<Korisnik>();


        public KorisnikController(MobixDbContext db)
        {
            _db = db;
        }
        [HttpGet("get-all-users")]
        public ActionResult<List<Korisnik>> GetAllUsers()
        {
            var data = _db.Users.OrderBy(p => p.Ime).AsQueryable();
            return data.ToList();
        }

        [HttpGet("get-user/{id}")]
        public IActionResult GetUsers(string id)
        {
            return Ok(_db.Users.FirstOrDefault(p => p.Id == id || (p.Ime + " " + p.Prezime).StartsWith(id) || (p.Prezime + " " + p.Ime).StartsWith(id)));
        }

        [EnableCors("AllowOrigin")]
        [HttpPost("add-user")]
        public ActionResult<Korisnik> AddKorisnik(KorisnikVM vm)
        {
            var p = new Korisnik
            {
                Ime = vm.Ime,
                Prezime = vm.Prezime
            };
            _db.Add(p);

            _db.SaveChanges();

            return p;
        }

        [HttpPut("edit-user/{id}")]
        public IActionResult EditKorisnik(string id, KorisnikVM podaci)
        {
            var odabraniUser = _db.Users.FirstOrDefault(pronadjeni => pronadjeni.Id == id);
            if (odabraniUser == null)
                return BadRequest("Korisnik sa tim IDom ne postoji");
            else
            {
                if (!podaci.Ime.IsNullOrEmpty())
                    odabraniUser.Ime = podaci.Ime;
                else
                    odabraniUser.Ime = odabraniUser.Ime;
                if (!podaci.Prezime.IsNullOrEmpty())
                    odabraniUser.Prezime = podaci.Prezime;
                else
                    odabraniUser.Prezime = odabraniUser.Prezime;
                if (!podaci.UserName.IsNullOrEmpty())
                {
                    odabraniUser.UserName = podaci.UserName ?? (odabraniUser.Ime + "." + odabraniUser.Prezime);

                    odabraniUser.NormalizedUserName = podaci.UserName.ToUpper();

                }
                else
                {
                    odabraniUser.UserName = (odabraniUser.Ime + "." + odabraniUser.Prezime);
                    odabraniUser.NormalizedUserName = (odabraniUser.Ime + "." + odabraniUser.Prezime).ToUpper();

                }
                if (!podaci.Email.IsNullOrEmpty())
                {
                    odabraniUser.Email = podaci.Email;
                    odabraniUser.NormalizedEmail = podaci.Email.ToUpper();

                }
                else
                {
                    odabraniUser.Email = odabraniUser.Email;
                }
                if (!podaci.Password.IsNullOrEmpty())
                {
                    odabraniUser.PasswordHash = hasher.HashPassword(null, podaci.Password);

                }
                else
                {
                    odabraniUser.PasswordHash = odabraniUser.PasswordHash;

                }
                if (!podaci.PhoneNumber.IsNullOrEmpty())
                {
                    odabraniUser.PhoneNumber = podaci.PhoneNumber;

                }
                else
                {
                    odabraniUser.PhoneNumber = odabraniUser.PhoneNumber;

                }
                if(!podaci.UserRole.IsNullOrEmpty())
                {
                    odabraniUser.UserRole = podaci.UserRole;
                }
                else
                {
                    odabraniUser.UserRole = odabraniUser.UserRole;
                }
                //TODO Add UserRole modification through EditKorisnik


                _db.Update(odabraniUser);
                _db.SaveChanges();
            }



            return Ok("Uspješno spašen " + odabraniUser);

        }


        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(string id)
        {
            var odabraniUser = _db.Users.FirstOrDefault(pronadjeni => pronadjeni.Id == id);

            if (odabraniUser == null)
                return BadRequest("Pogrešan ID");

            _db.Remove(odabraniUser);
            _db.SaveChanges();

            return Ok();
        }

    }
}

