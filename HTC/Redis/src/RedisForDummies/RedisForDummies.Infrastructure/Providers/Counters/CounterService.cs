using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using RedisForDummies.Application.Caches.ApacheIgnite;
using RedisForDummies.Application.Caches.Redis;
using RedisForDummies.Application.Providers.Counters;

namespace RedisForDummies.Infrastructure.Providers.Counters
{
    /// <summary>
    /// Сервис Счетчиков.
    /// </summary>
    public class CounterService : ICounterService
    {
        /// <summary>
        /// Распределенный кэш, представленный Apache Ignite'ом.
        /// </summary>
        protected IApacheIgniteDistributedCache _apacheIgniteCache { get; }
        /// <summary>
        /// Логгер.
        /// </summary>
        protected ILogger<CounterService> _logger { get; }
        /// <summary>
        /// Распределенный кэш, представленный Redis'ом.
        /// </summary>
        protected IRedisDistributedCache _redisCache { get; }

        /// <summary>
        /// Инициализировать новый экземпляр класса <see cref="CounterService"/>.
        /// </summary>
        /// <param name="apacheIgniteCache">Распределенный кэш, представленный Apache Ignite'ом.</param>
        /// <param name="logger">Логгер.</param>
        /// <param name="redisCache">Распределенный кэш, представленный Redis'ом.</param>
        public CounterService(
            IApacheIgniteDistributedCache apacheIgniteCache,
            ILogger<CounterService> logger,
            IRedisDistributedCache redisCache)
        {
            _apacheIgniteCache = apacheIgniteCache;
            _logger = logger;
            _redisCache = redisCache;
        }

        /// <inheritdoc/>
        public Task<int> GetFromApacheIgniteAsync(string key) =>
            GetFromCache(_apacheIgniteCache, key);

        /// <inheritdoc/>
        public Task<int> GetFromRedisAsync(string key) =>
            GetFromCache(_redisCache, key);

        /// <summary>
        /// Получить значение Счетчика из кэша.
        /// </summary>
        /// <param name="cache">Используемый кэш.</param>
        /// <param name="key">Ключ Счетчика.</param>
        /// <returns>Значение Счетчика.</returns>
        private static async Task<int> GetFromCache(IDistributedCache cache, string key)
        {
            string? counterStr;
            int returnValue;

            counterStr = await cache.GetStringAsync(key);
            if (int.TryParse(counterStr, out int counter))
            {
                counter = counter + 1;
            }
            else
            {
                counter = 0;
            }

            returnValue = counter;
            await cache.SetStringAsync(key, returnValue.ToString());

            return returnValue;
        }
    }
}
