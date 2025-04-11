using Microsoft.Extensions.Caching.Distributed;

namespace RedisForDummies.Application.Caches.ApacheIgnite
{
    /// <summary>
    /// Контракт Распределенного кэша, представленного Apache Ignite.
    /// </summary>
    public interface IApacheIgniteDistributedCache : IDistributedCache
    {
    }
}
