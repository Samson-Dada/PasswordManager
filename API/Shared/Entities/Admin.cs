using Microsoft.AspNetCore.Identity;

namespace API.Shared.Entities
{
    public class Admin : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
