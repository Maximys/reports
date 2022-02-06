using Data.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
            Database.Migrate();
        }
    }
}
