using JwtApiMez.Models;
using Microsoft.AspNetCore.Http;

namespace JwtApiMez.AuthenticationUtils
{
    public interface IJwtAuthenticationService
    {
        User Authenticate(LoginModel model);
        string GenerateToken(User user);
        User GetCurrentUserFromHttpContext(HttpContext httpContext);
    }
}
