using Microsoft.AspNetCore.Mvc;
using RedisForDummies.Application.Providers.Counters;

namespace RedisForDummies.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы со Счетчиками.
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class CounterController : ControllerBase
    {
        /// <summary>
        /// Сервис Счетчиков.
        /// </summary>
        protected ICounterService _counterService { get; }

        public CounterController(ICounterService counterService)
        {
            _counterService = counterService;
        }

        /// <summary>
        /// Получить значение Счетчика из кэша Apache Ignite'а.
        /// </summary>
        /// <param name="counterKey">Ключ Счетчика.</param>
        /// <returns>Значение Счетчика из кэша Apache Ignite'а.</returns>
        [HttpGet]
        public async Task<int> GetFromApacheIgniteAsync(string counterKey)
        {
            int returnValue;

            returnValue = await _counterService.GetFromApacheIgniteAsync(counterKey);

            return returnValue;
        }

        /// <summary>
        /// Получить значение Счетчика из кэша Redis'а.
        /// </summary>
        /// <param name="counterKey">Ключ Счетчика.</param>
        /// <returns>Значение Счетчика из кэша Redis'а.</returns>
        [HttpGet]
        public async Task<int> GetFromRedisAsync(string counterKey)
        {
            int returnValue;

            returnValue = await _counterService.GetFromRedisAsync(counterKey);

            return returnValue;
        }
    }
}
