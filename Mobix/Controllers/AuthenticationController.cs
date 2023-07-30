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

        public AuthenticationController(SignInManager<Korisnik> signInManager, UserManager<Korisnik> userManager, MobixDbContext db, JwtHandler jwtHandler)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _db = db;
            _jwtHandler = jwtHandler;
        }

        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        //{
        //    // TODO: Implement user registration logic using _userManager and _dbContext

        //    return Ok();
        //}

        // Action for user login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginVM model)
        {
            if (!ModelState.IsValid || model == null)
            {
                return new BadRequestObjectResult(new { Message = "Login failed" });
            }

            var identityUser = await _userManager.FindByNameAsync(model.Email);
            var identityUser1 = await _userManager.FindByEmailAsync(model.Email);
            if (identityUser == null)
            {
                var result = _userManager.PasswordHasher.VerifyHashedPassword(identityUser1, identityUser1.PasswordHash, model.Password);
                if (result == PasswordVerificationResult.Failed)
                {
                    return new BadRequestObjectResult(new { Message = "Login failed" });
                }
                var roles = await _userManager.GetRolesAsync(identityUser1);
                var userRole = identityUser1.UserRole;
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
                    return new BadRequestObjectResult(new { Message = "Login failed" });
                }
                var roles = await _userManager.GetRolesAsync(identityUser);
                var userRole = identityUser.UserRole;
                var signingCredentials = _jwtHandler.GetSigningCredentials();
                var claims = _jwtHandler.GetClaims(identityUser);
                var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return Ok(new AuthResponseDTO { IsAuthSuccessful = true, Token = token, Role = userRole });
            }

            
            
            else
            {
                return BadRequest("Something went wrong");
            }



        }

        // Action for user logout
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok(new { Message = "You are logged out" });
        }
    }
}
