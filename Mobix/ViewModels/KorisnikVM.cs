using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Mobix.ViewModels
{
    public class KorisnikVM:IdentityUser
    {
        //public string Id { get; set; }
        [UIHint("Type in your first name")]
        public string? Ime { get; set; }

        [UIHint("Type in your second name")]
        public string? Prezime { get; set; }
        [UIHint("Type in a password")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string? Password { get; set; }
        [UIHint("Retype your password")]
        [Compare("Password", ErrorMessage = "Password and Password Check must match.")]
        public string? PasswordPotvrda { get; set; }
        public string? UserRole { get; set; }

        //[Required(ErrorMessage = "1 - Admin, 2 - User")]
        //public int RoleNumber { get; set; }
    }
}
