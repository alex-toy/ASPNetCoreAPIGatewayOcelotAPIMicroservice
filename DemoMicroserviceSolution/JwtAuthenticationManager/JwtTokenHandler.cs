using JwtAuthenticationManager.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthenticationManager
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "eyJhbGciOiJIUzI1NiJ9.eyJSb2xlIjoiQWRtaW4iLCJJc3N1ZXIiOiJJc3N1ZXIiLCJVc2VybmFtZSI6IkphdmFJblVzZSIsImV4cCI6MTY3Mzc3NDY2NywiaWF0IjoxNjczNzc0NjY3fQ.XzfLCkiF8MSx9zZIk09JQr5W9k8-YXW3ftajrorBXyE";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;
        private readonly List<UserAccount> userAccounts;

        public JwtTokenHandler()
        {
            userAccounts = new List<UserAccount>
            {
                new UserAccount{ UserName = "admin", Password = "admin123", Role = "Administrator", },
                new UserAccount{ UserName = "user01", Password = "user01", Role = "User", }
            };
        }

        public AuthenticationResponse? GenerateJwtToken(AuthenticationRequest authenticationRequest)
        {
            bool noUserName = string.IsNullOrEmpty(authenticationRequest.UserName);
            bool noPassword = string.IsNullOrEmpty(authenticationRequest.Password);

            if (noUserName || noPassword)
            {
                return null;
            }

            UserAccount? userAccount = userAccounts.Where(x => { 
                return x.UserName == authenticationRequest.UserName && x.Password == authenticationRequest.Password; 
            }).FirstOrDefault();

            if (userAccount == null) return null;

            DateTime tokenExpiryTimeInSeconds = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            byte[]? TokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);

            ClaimsIdentity? claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, authenticationRequest.UserName),
                new Claim(ClaimTypes.Role, userAccount.Role),
            });

            SigningCredentials? signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(TokenKey), 
                SecurityAlgorithms.HmacSha256Signature
            );

            SecurityTokenDescriptor? securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeInSeconds,
                SigningCredentials = signingCredentials 
            };

            JwtSecurityTokenHandler? jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken? securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            string? token = jwtSecurityTokenHandler?.WriteToken(securityToken);

            return new AuthenticationResponse
            {
                UserName = userAccount.UserName,
                ExpiresIn = (int)tokenExpiryTimeInSeconds.Subtract(DateTime.Now).TotalSeconds,
                JwtToken = token
            };
        }
    }
}