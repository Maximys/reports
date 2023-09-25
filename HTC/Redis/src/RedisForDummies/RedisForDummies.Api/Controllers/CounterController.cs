using Microsoft.AspNetCore.Mvc;
using RedisForDummies.Application.Providers.Counters;

namespace RedisForDummies.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы со Счетчиками.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
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
        /// Получить значение Счетчика.
        /// </summary>
        /// <param name="counterKey">Ключ Счетчика.</param>
        /// <returns>Значение Счетчика.</returns>
        [HttpGet]
        public async Task<int> GetAsync(string counterKey)
        {
            int returnValue;

            returnValue = await _counterService.GetAsync(counterKey);

            return returnValue;
        }
    }
}
