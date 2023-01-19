using JwtAuthDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromForm] AuthenticationRequest authenticationRequest)
        {
            var jwtAuthenticationManager = new JwtAuthenticationManager();
            User user = new User { Name = authenticationRequest.UserName, Password = authenticationRequest.Password };
            var authResult = jwtAuthenticationManager.Authenticate(user);

            if (authResult == null) return Unauthorized();

            return Ok(authResult);
        }
    }
}
