using JwtApiMez.AuthenticationUtils;
using JwtApiMez.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtApiMez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputeController : ControllerBase
    {
        private readonly IJwtAuthenticationService _jwtAuthService;

        public ComputeController(IJwtAuthenticationService jwtAuthenticationService)
        {
            _jwtAuthService = jwtAuthenticationService;
        }

        [AllowAnonymous]
        [HttpGet("double")]
        public IActionResult Double(int value)
        {
            return Ok($"The double is {value*2}");
        }

        [HttpPost("Multiply")]
        [Authorize(Roles = "dev")]
        public IActionResult Multiply([FromBody] ComputeModel compute)
        {
            User user = _jwtAuthService.GetCurrentUserFromHttpContext(HttpContext);

            return Ok($"Hi {user.Name}, you are a {user.Role}. The result is {compute.Value1 * compute.Value2}");
        }

        [HttpPost("Divide")]
        [Authorize(Roles = "admin")]
        public IActionResult Divide([FromBody] ComputeModel compute)
        {
            User user = _jwtAuthService.GetCurrentUserFromHttpContext(HttpContext);

            return Ok($"Hi {user.Name}, you are a {user.Role}. The result is {compute.Value1 / compute.Value2}");
        }
    }
}
