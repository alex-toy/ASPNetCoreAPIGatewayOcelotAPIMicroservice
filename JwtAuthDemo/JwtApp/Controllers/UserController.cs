using JwtApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace JwtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("Admins")]
        [Authorize(Roles = "Administrator")]
        public IActionResult AdminsEndpoint()
        {
            var currentUser = GetCurrentUserFromHttpContext();

            return Ok($"Hi {currentUser.GivenName}, you are an {currentUser.Role}");
        }

        [HttpGet("Sellers")]
        [Authorize(Roles = "Seller")]
        public IActionResult SellersEndpoint()
        {
            UserModel currentUser = GetCurrentUserFromHttpContext();

            return Ok($"Hi {currentUser.GivenName}, you are a {currentUser.Role}");
        }

        [HttpGet("AdminsAndSellers")]
        [Authorize(Roles = "Administrator,Seller")]
        public IActionResult AdminsAndSellersEndpoint()
        {
            UserModel currentUser = GetCurrentUserFromHttpContext();

            return Ok($"Hi {currentUser.GivenName}, you are an {currentUser.Role}");
        }

        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("Hi, you're on public property");
        }

        private UserModel GetCurrentUserFromHttpContext()
        {
            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity == null) return null;

            UserModel userModel = GetUserModelFromClaim(identity);
            return userModel;
        }

        private UserModel GetUserModelFromClaim(ClaimsIdentity identity)
        {
            IEnumerable<Claim> userClaims = identity.Claims;

            return new UserModel
            {
                Username = userClaims.ExtractUserClaim(ClaimTypes.NameIdentifier),
                EmailAddress = userClaims.ExtractUserClaim(ClaimTypes.Email),
                GivenName = userClaims.ExtractUserClaim(ClaimTypes.GivenName),
                Surname = userClaims.ExtractUserClaim(ClaimTypes.Surname),
                Role = userClaims.ExtractUserClaim(ClaimTypes.Role)
            };
        }
    }
}
