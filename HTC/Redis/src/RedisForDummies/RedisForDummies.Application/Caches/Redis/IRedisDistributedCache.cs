using Microsoft.Extensions.Caching.Distributed;

namespace RedisForDummies.Application.Caches.Redis
{
    /// <summary>
    /// Контракт Распределенного кэша, представленного Redis.
    /// </summary>
    public interface IRedisDistributedCache : IDistributedCache
    {
    }
}
