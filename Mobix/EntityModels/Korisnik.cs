using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobix.EntityModels
{
    public class Korisnik : IdentityUser
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? UserRole { get; set; }
        public string? EmailVerificationToken { get; set; }
        //public ICollection<IdentityRole> Uloge { get; set; }
    }
}
