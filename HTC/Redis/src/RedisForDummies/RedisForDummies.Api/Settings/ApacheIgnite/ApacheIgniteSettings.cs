namespace RedisForDummies.Api.Settings.ApacheIgnite
{
    /// <summary>
    /// Настройки для работы с Apache Ignite.
    /// </summary>
    public class ApacheIgniteSettings
    {
        /// <summary>
        /// Точки подключения к Apache Ignite.
        /// </summary>
        public string[] Endpoints { get; set; } = Enumerable.Empty<string>()
            .ToArray();

        /// <summary>
        /// Настройки для инициализации.
        /// </summary>
        public InitializationSettings Initialization { get; set; } = new InitializationSettings();
    }
}
