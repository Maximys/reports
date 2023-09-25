namespace RedisForDummies.Application.Providers.Counters
{
    /// <summary>
    /// Контракт Сервиса Счетчиков.
    /// </summary>
    public interface ICounterService
    {
        /// <summary>
        /// Получить значение Счетчика.
        /// </summary>
        /// <param name="key">Ключ Счетчика.</param>
        /// <returns>Значение Счетчика.</returns>
        Task<int> GetAsync(string key);
    }
}
