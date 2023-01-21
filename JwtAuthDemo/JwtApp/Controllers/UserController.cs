using JwtApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
            var currentUser = GetCurrentUser();

            return Ok($"Hi {currentUser.GivenName}, you are an {currentUser.Role}");
        }


        [HttpGet("Sellers")]
        [Authorize(Roles = "Seller")]
        public IActionResult SellersEndpoint()
        {
            UserModel currentUser = GetCurrentUser();

            return Ok($"Hi {currentUser.GivenName}, you are a {currentUser.Role}");
        }

        [HttpGet("AdminsAndSellers")]
        [Authorize(Roles = "Administrator,Seller")]
        public IActionResult AdminsAndSellersEndpoint()
        {
            UserModel currentUser = GetCurrentUser();

            return Ok($"Hi {currentUser.GivenName}, you are an {currentUser.Role}");
        }

        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("Hi, you're on public property");
        }

        private UserModel GetCurrentUser()
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
                Username = userClaims.GetUserClaim(ClaimTypes.NameIdentifier),
                EmailAddress = userClaims.GetUserClaim(ClaimTypes.Email),
                GivenName = userClaims.GetUserClaim(ClaimTypes.GivenName),
                Surname = userClaims.GetUserClaim(ClaimTypes.Surname),
                Role = userClaims.GetUserClaim(ClaimTypes.Role)
            };
        }
    }
}
