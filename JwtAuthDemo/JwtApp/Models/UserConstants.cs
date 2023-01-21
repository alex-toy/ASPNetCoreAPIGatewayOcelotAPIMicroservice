using System.Collections.Generic;

namespace JwtApp.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username = "alex", EmailAddress = "alex.admin@email.com", Password = "MyPass_w0rd", GivenName = "Jason", Surname = "Bryant", Role = "Administrator" },
            new UserModel() { Username = "seb", EmailAddress = "seb@email.com", Password = "MyPass_w0rd", GivenName = "Elyse", Surname = "Lambert", Role = "Seller" },
        };
    }
}
