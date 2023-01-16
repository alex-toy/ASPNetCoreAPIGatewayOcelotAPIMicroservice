using JwtAuthDemo.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace JwtAuthDemo
{
    public class JwtAuthenticationManager
    {
        public static List<User> users { get; set; } = new()
        {
            new User { Name = "alex", Password = "alex" },
            new User { Name = "seb", Password = "seb" },
            new User { Name = "kate", Password = "kate" },
        };

        public JwtAuthResponse Authenticate(User user)
        {
            User userDb = GetUserDb(user);
            if ( userDb == null || userDb.Password != user.Password)
            {
                return null;
            }

            DateTime tokenExpiryTimeStamp = DateTime.Now.AddMinutes(Constants.JWT_TOKEN_VALIDITY_MINS);
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            byte[] tokenKey = Encoding.ASCII.GetBytes(Constants.JWT_SECURITY_KEY);
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new List<Claim>
                {
                    new Claim("username", user.Name),
                    new Claim(ClaimTypes.PrimaryGroupSid, "User Group 01")
                }),
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            string token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new JwtAuthResponse
            {
                token = token,
                user_name = user.Name,
                expires_in = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };
        }

        private User GetUserDb(User user)
        {
            return users.FirstOrDefault(u => u.Name == user.Name);
        }
    }
}
