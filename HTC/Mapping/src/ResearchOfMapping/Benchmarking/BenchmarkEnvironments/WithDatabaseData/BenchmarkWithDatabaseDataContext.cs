using Benchmarking.Entities.Source;
using Microsoft.EntityFrameworkCore;

namespace Benchmarking.BenchmarkEnvironments.WithDatabaseData
{
    public class BenchmarkWithDatabaseDataContext : DbContext
    {
        public DbSet<Foo> Foos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=dbForBenchmark;Username=userForBenchmark;Password=123456");
        }
    }
}
