namespace RedisForDummies.Application.Providers.Counters
{
    /// <summary>
    /// Контракт Сервиса Счетчиков.
    /// </summary>
    public interface ICounterService
    {
        /// <summary>
        /// Получить значение Счетчика из кэша Apache Ignite'а.
        /// </summary>
        /// <param name="key">Ключ Счетчика.</param>
        /// <returns>Значение Счетчика из кэша Apache Ignite'а.</returns>
        Task<int> GetFromApacheIgniteAsync(string key);

        /// <summary>
        /// Получить значение Счетчика из кэша Redis'а.
        /// </summary>
        /// <param name="key">Ключ Счетчика.</param>
        /// <returns>Значение Счетчика из кэша Redis'а.</returns>
        Task<int> GetFromRedisAsync(string key);
    }
}
