namespace RedisForDummies.Api.Settings
{
    /// <summary>
    /// Настройки для работы с Redis.
    /// </summary>
    public class RedisSettings
    {
        /// <summary>
        /// Параметры подключения.
        /// </summary>
        public string? Configuration { get; set; }

        /// <summary>
        /// Имя экземпляра.
        /// </summary>
        public string? InstanceName { get; set; }
    }
}
