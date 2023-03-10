using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace JwtApiMez.Models
{
    public static class UserClaimExtension
    {
        public static string ExtractUserClaim(this IEnumerable<Claim> userClaims, string value)
        {
            return userClaims.FirstOrDefault(claim => claim.Type == value)?.Value;
        }
    }
}
