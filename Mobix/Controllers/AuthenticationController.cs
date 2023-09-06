using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mobix.Data;
using Mobix.EntityModels;
using Mobix.ViewModels;
using System.Security.Claims;
using Mobix.JwtFeatures;
using Mobix.DTO;
using System.IdentityModel.Tokens.Jwt;
using Mobix.EmailServis;

namespace Mobix.Controllers
{
    [ApiController]
    [Route("api/")]
    public class AuthenticationController : ControllerBase
    {
        private readonly SignInManager<Korisnik> _signInManager;
        private readonly UserManager<Korisnik> _userManager;
        private readonly MobixDbContext _db;
        private readonly JwtHandler _jwtHandler;
        private readonly EmailService _emailService;

        public AuthenticationController(SignInManager<Korisnik> signInManager, UserManager<Korisnik> userManager, MobixDbContext db, JwtHandler jwtHandler, EmailService emailService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _db = db;
            _jwtHandler = jwtHandler;
            _emailService = emailService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistracijaVM registracija)
        {
            if (!ModelState.IsValid || registracija == null)
            {
                return new BadRequestObjectResult(new { Message = "Invalid registration data" });
            }

            var noviKorisnik = new Korisnik
            {
                Ime = registracija.Ime,
                Prezime = registracija.Prezime,
                UserName = registracija.Email,
                Email = registracija.Email,
                EmailConfirmed = false,
                UserRole = "Korisnik",
                EmailVerificationToken = Guid.NewGuid().ToString(),
            };

            var createResult = await _userManager.CreateAsync(noviKorisnik, registracija.Password);

            if (createResult.Succeeded)
            {
                // slanje konfirmacijskog maila
                var confirmationLink = Url.Action("ConfirmEmail", "Authentication", new { userId = noviKorisnik.Id, token = noviKorisnik.EmailVerificationToken }, Request.Scheme);
                var emailContent = $"Please confirm your email by clicking this link: <a href='{confirmationLink}'>Confirm Email</a>";
                await _emailService.SendEmailAsync(noviKorisnik.Email, "Confirm Your Email", emailContent);

                // poruka za uspjeh registracije
                return Ok(new { Message = "Registration successful. Please check your email to confirm."});
            }
            else
            {
                return new BadRequestObjectResult(new { Message = "Registration failed" });
            }
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return BadRequest("Nevazeci konfirmacijski link.");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest("Korisnik nije pronadjen.");
            }

            user.EmailConfirmed = true;
            user.EmailVerificationToken = null;
            await _userManager.UpdateAsync(user);

            return Ok("Email potvrdjen!");
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginVM model)
        {
            if (!ModelState.IsValid || model == null)
            {
                return new BadRequestObjectResult(new { Message = "Neuspjeli login" });
            }

            var identityUser = await _userManager.FindByNameAsync(model.Email);
            var identityUser1 = await _userManager.FindByEmailAsync(model.Email);
            if(identityUser.EmailConfirmed == false)
            {
                return BadRequest("Email nije potvrdjen");
            }
            if (identityUser == null)
            {
                var result = _userManager.PasswordHasher.VerifyHashedPassword(identityUser1, identityUser1.PasswordHash, model.Password);
                if (result == PasswordVerificationResult.Failed)
                {
                    return new BadRequestObjectResult(new { Message = "Neuspjeli login" });
                }
                var roles = await _userManager.GetRolesAsync(identityUser1);
                var userRole = identityUser1.UserRole;
                var userId = identityUser1.Id;
                var signingCredentials = _jwtHandler.GetSigningCredentials();
                var claims = _jwtHandler.GetClaims(identityUser1);
                var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return Ok(new AuthResponseDTO { IsAuthSuccessful = true, Token = token, Role = userRole });
               
            }
            else if(identityUser!=null)
            {
                var result = _userManager.PasswordHasher.VerifyHashedPassword(identityUser, identityUser.PasswordHash, model.Password);
                if (result == PasswordVerificationResult.Failed)
                {
                    return new BadRequestObjectResult(new { Message = "Neuspjeli login" });
                }
                var roles = await _userManager.GetRolesAsync(identityUser);
                var userRole = roles.FirstOrDefault();
                var userId = identityUser.Id;
                var signingCredentials = _jwtHandler.GetSigningCredentials();
                var claims = _jwtHandler.GetClaims(identityUser);
                var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return Ok(new AuthResponseDTO { IsAuthSuccessful = true, Token = token, Role = userRole, KorisnikId = userId });
            }

            else
            {
                return BadRequest("Nesto nije u redu.");
            }

        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok(new { Message = "Logout izvrsen" });
        }
    }
}
