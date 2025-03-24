using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;
using RedisForDummies.Application.Caches.Redis;

namespace RedisForDummies.Infrastructure.Caches.Redis
{
    /// <summary>
    /// Распределенный кэш, представленный Redis'ом.
    /// </summary>
    public class RedisDistributedCache : RedisCache, IRedisDistributedCache
    {
        /// <summary>
        /// Initializes a new instance of <see cref="RedisDistributedCache"/>.
        /// </summary>
        /// <param name="optionsAccessor">Настройки кэша.</param>
        public RedisDistributedCache(IOptions<RedisCacheOptions> optionsAccessor)
            : base(optionsAccessor)
        {
        }
    }
}
