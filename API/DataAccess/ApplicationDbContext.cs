using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntitiesSeedData.SeedData(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }
    }
}
