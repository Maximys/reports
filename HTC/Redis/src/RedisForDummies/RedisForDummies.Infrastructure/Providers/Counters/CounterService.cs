using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using RedisForDummies.Application.Providers.Counters;

namespace RedisForDummies.Infrastructure.Providers.Counters
{
    /// <summary>
    /// Сервис Счетчиков.
    /// </summary>
    public class CounterService : ICounterService
    {
        /// <summary>
        /// Распределенный кэш.
        /// </summary>
        protected IDistributedCache _cache { get; }
        /// <summary>
        /// Логгер.
        /// </summary>
        protected ILogger<CounterService> _logger { get; }

        /// <summary>
        /// Инициализировать новый экземпляр класса <see cref="CounterService"/>.
        /// </summary>
        /// <param name="cache">Распределенный кэш.</param>
        /// <param name="logger">Логгер.</param>
        public CounterService(IDistributedCache cache, ILogger<CounterService> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<int> GetAsync(string key)
        {
            string? counterStr;
            int returnValue;

            counterStr = await _cache.GetStringAsync(key);
            if (int.TryParse(counterStr, out int counter))
            {
                counter = counter + 1;
            }
            else
            {
                counter = 0;
            }

            returnValue = counter;
            await _cache.SetStringAsync(key, returnValue.ToString());

            return returnValue;
        }
    }
}
