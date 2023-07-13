using System.ComponentModel.DataAnnotations;

namespace Mobix.DTO
{
    public class AutentifikacijaDTO
    {
        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }
    }
}
