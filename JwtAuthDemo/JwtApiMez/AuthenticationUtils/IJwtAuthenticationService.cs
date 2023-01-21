using JwtApiMez.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace JwtApiMez.AuthenticationUtils
{
    public interface IJwtAuthenticationService
    {
        User Authenticate(string email, string password);
        string GenerateToken(string secret, List<Claim> claims);
    }
}
