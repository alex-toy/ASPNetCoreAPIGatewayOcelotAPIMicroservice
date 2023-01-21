using JwtApiMez.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace JwtApiMez.AuthenticationUtils
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        private readonly IConfiguration _config;

        public JwtAuthenticationService(IConfiguration config)
        {
            _config = config;
        }

        public IEnumerable<User> GetUsersFromDB()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "alex",
                    Email = "alex@test.com",
                    Password = "alex",
                    Role = "admin"
                },
                new User
                {
                    Id = 2,
                    Name = "seb",
                    Email = "seb@test.com",
                    Password = "seb",
                    Role = "dev"
                }
            };
        }

        public User Authenticate(LoginModel login)
        {
            var users = GetUsersFromDB();
            return users.Where(u => u.Email.ToUpper().Equals(login.Email.ToUpper()) && u.Password.Equals(login.Password)).FirstOrDefault();
        }

        private static List<Claim> GetClaims(User user)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role)
            };
        }

        public string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var claims = GetClaims(user);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public User GetCurrentUserFromHttpContext(HttpContext httpContext)
        {
            ClaimsIdentity identity = httpContext.User.Identity as ClaimsIdentity;

            if (identity == null) return null;

            User user = GetUserModelFromClaim(identity);
            return user;
        }

        private User GetUserModelFromClaim(ClaimsIdentity identity)
        {
            IEnumerable<Claim> userClaims = identity.Claims;

            return new User
            {
                Name = userClaims.ExtractUserClaim(ClaimTypes.Name),
                Email = userClaims.ExtractUserClaim(ClaimTypes.Email),
                Role = userClaims.ExtractUserClaim(ClaimTypes.Role)
            };
        }
    }
}