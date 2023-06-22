using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess
{
    public class EntitiesSeedData
    {

        public static void SeedData(ModelBuilder modelBuilder)
        {
            var user = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Username = "keepy",
                    Email = "johnd@mail.com",
                    Password = "12345333ddd",
                },
                  new User()
                {
                    Id = 2,
                    Username = "keepy",
                    Email = "johnd@mail.com",
                    Password = "12345333ddd",
                  }
            };
            modelBuilder.Entity<User>().HasData(user);
        }
    }
}
