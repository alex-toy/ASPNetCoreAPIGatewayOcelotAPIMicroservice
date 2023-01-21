using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace JwtApp
{
    public static class UserClaimExtension
    {
        public static string GetUserClaim(this IEnumerable<Claim> userClaims, string value)
        {
            return userClaims.FirstOrDefault(claim => claim.Type == value)?.Value;
        }
    }
}
