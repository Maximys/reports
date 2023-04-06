using AutoFixture;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using Benchmarking.Entities.Destination;
using Benchmarking.Entities.Source;
using Mapster;

namespace Benchmarking.BenchmarkEnvironments
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        private const int N = 500_000;

        private readonly IEnumerable<Foo> data;

        protected Mapper Mapper { get; }

        public Benchmark()
        {
            MapperConfiguration mapperConfiguration;

            mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<InnerFoo, InnerFooDest>();
                cfg.CreateMap<Foo, FooDest>();
            });
            Mapper = new Mapper(mapperConfiguration);


            Fixture fixture = new Fixture();
            data = fixture.CreateMany<Foo>(N);
        }

        [Benchmark]
        public List<FooDest> AutoMapper() => Mapper.Map<IEnumerable<FooDest>>(data).ToList();

        [Benchmark]
        public List<FooDest> Mapster() => data.Adapt<IEnumerable<FooDest>>().ToList();
    }
}
