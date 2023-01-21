using JwtApiMez.AuthenticationUtils;
using JwtApiMez.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JwtApiMez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtAuthenticationService _jwtAuthService;
        private readonly IConfiguration _config;

        public AuthenticationController(IJwtAuthenticationService JwtAuthenticationService, IConfiguration config)
        {
            _jwtAuthService = JwtAuthenticationService;
            _config = config;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user = _jwtAuthService.Authenticate(model);
            if (user == null) return Unauthorized();

            var token = _jwtAuthService.GenerateToken(user);
            return Ok(token);
        }
    }
}
