using AutoMapper;
using Benchmarking.Entities.Destination;
using Benchmarking.Entities.Source;

namespace Benchmarking.BenchmarkEnvironments.Base
{
    public abstract class BenchmarkBase
    {
        protected MapperConfiguration CurrentMapperConfiguration { get; private set; }

        protected void InitEnvironment()
        {
            CurrentMapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<InnerFoo, InnerFooDest>();
                cfg.CreateMap<Foo, FooDest>();
            });
        }
    }
}
