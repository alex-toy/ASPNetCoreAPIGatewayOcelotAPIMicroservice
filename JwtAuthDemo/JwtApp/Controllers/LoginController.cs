using JwtApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JwtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            UserModel user = Authenticate(userLogin);

            if (user == null) return NotFound("User not found");

            string token = GenerateToken(user);
            return Ok(token);
        }

        private string GenerateToken(UserModel user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.GivenName, user.GivenName),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Role, user.Role)
            };

            JwtSecurityToken token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"],
                                                          claims, expires: DateTime.Now.AddMinutes(15),
                                                          signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel Authenticate(UserLogin userLogin)
        {
            UserModel userDb = UserConstants.Users.FirstOrDefault(userDb => IsUserDb(userLogin, userDb));

            return userDb ?? null;
        }

        private static bool IsUserDb(UserLogin userLogin, UserModel userModel)
        {
            return userModel.Username.ToLower() == userLogin.Username.ToLower() && userModel.Password == userLogin.Password;
        }
    }
}
