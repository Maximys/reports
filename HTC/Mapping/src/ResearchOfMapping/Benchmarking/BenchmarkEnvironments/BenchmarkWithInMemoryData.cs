using AutoFixture;
using AutoMapper;
using BenchmarkDotNet.Attributes;
using Benchmarking.BenchmarkEnvironments.Base;
using Benchmarking.Entities.Destination;
using Benchmarking.Entities.Source;
using Benchmarking.MapperlyEnvironments;
using Mapster;

namespace Benchmarking.BenchmarkEnvironments
{
    [MemoryDiagnoser]
    public class BenchmarkWithInMemoryData : BenchmarkBase
    {
        protected const int N = 500_000;

        protected IEnumerable<Foo> Data { get; set; }

        protected Mapper Mapper { get; }

        public BenchmarkWithInMemoryData()
        {
            InitEnvironment();
            Mapper = new Mapper(CurrentMapperConfiguration);
        }

        [Benchmark]
        public List<FooDest> AutoMapper() => Mapper.Map<IEnumerable<FooDest>>(Data).ToList();

        [Benchmark]
        public List<FooDest> Mapster() => Data.Adapt<IEnumerable<FooDest>>().ToList();

        [Benchmark]
        public List<FooDest> Mapperly() => FooMapper.MapFooToDest(Data).ToList();

        [GlobalSetup]
        public void GlobalSetup()
        {
            Fixture fixture = new Fixture();
            Data = fixture.CreateMany<Foo>(N);
        }
    }
}
