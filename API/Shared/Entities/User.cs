using Microsoft.AspNetCore.Identity;

namespace API.Shared.Entities
{
    public class User : IdentityUser
    {
        //public User()
        //{
        //    Password = new List<Password>();
        //}
        //public ICollection<Password> Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
//public bool IsAdmin { get; set; }
