using System.Collections.Generic;

namespace JwtApp.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username = "alex", EmailAddress = "alex.admin@email.com", Password = "alex", GivenName = "alex", Surname = "Bryant", Role = "Administrator" },
            new UserModel() { Username = "seb", EmailAddress = "seb@email.com", Password = "seb", GivenName = "seb", Surname = "Lambert", Role = "Seller" },
        };
    }
}
