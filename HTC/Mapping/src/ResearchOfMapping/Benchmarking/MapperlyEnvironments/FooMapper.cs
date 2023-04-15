using Benchmarking.Entities.Destination;
using Benchmarking.Entities.Source;
using Riok.Mapperly.Abstractions;

namespace Benchmarking.MapperlyEnvironments
{
    [Mapper]
    public static partial class FooMapper
    {
        public static partial IEnumerable<FooDest> MapFooToDest(IEnumerable<Foo> foo);
    }
}
