using API.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Shared.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }
    }
}
