using AutoFixture;
using AutoMapper.QueryableExtensions;
using BenchmarkDotNet.Attributes;
using Benchmarking.BenchmarkEnvironments.Base;
using Benchmarking.Entities.Destination;
using Benchmarking.Entities.Source;
using Benchmarking.Fakers.SpecimenBuilders;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Benchmarking.BenchmarkEnvironments.WithDatabaseData
{
    [MemoryDiagnoser]
    public class BenchmarkWithDatabaseData : BenchmarkBase
    {
        protected const int N = 50_000;

        public BenchmarkWithDatabaseData()
        {
            InitEnvironment();
        }

        [Benchmark]
        public List<FooDest> AutoMapper()
        {
            List<FooDest> returnValue;

            using (BenchmarkWithDatabaseDataContext dbContext = new BenchmarkWithDatabaseDataContext())
            {
                returnValue = dbContext.Foos
                    .Include(f => f.Foo1)
                    .Include(f => f.Foos)
                    .Include(f => f.FooArr)
                    .ProjectTo<FooDest>(CurrentMapperConfiguration)
                    .ToList();
            }

            return returnValue;
        }

        [Benchmark]
        public List<FooDest> Mapster()
        {
            List<FooDest> returnValue;

            using (BenchmarkWithDatabaseDataContext dbContext = new BenchmarkWithDatabaseDataContext())
            {
#if false
                returnValue = dbContext.Foos
                    .Include(f => f.Foo1)
                    .Include(f => f.Foos)
                    .Include(f => f.FooArr)
                    .ProjectToType<FooDest>()
                    .ToList();
#else
                returnValue = dbContext.Foos
                    .Include(f => f.Foo1)
                    .Include(f => f.Foos)
                    .Include(f => f.FooArr)
                    .ToList()
                    .Adapt<IEnumerable<FooDest>>()
                    .ToList();
#endif
            }

            return returnValue;
        }

        [GlobalSetup]
        public void GlobalSetup()
        {
            Fixture fixture = new Fixture();
            fixture.Customizations.Add(new UtcRandomDateTimeSequenceGenerator());

            using (BenchmarkWithDatabaseDataContext dbContext = new BenchmarkWithDatabaseDataContext())
            {
                dbContext.Database.Migrate();

                if (!dbContext.Foos.Any())
                {
                    IEnumerable<Foo> data = fixture.CreateMany<Foo>(N);
                    dbContext.Foos.AddRange(data);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
