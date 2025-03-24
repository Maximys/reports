namespace RedisForDummies.Api.Settings.ApacheIgnite
{
    /// <summary>
    /// Настройки для инициализации Apache Ignite.
    /// </summary>
    public class InitializationSettings
    {
        /// <summary>
        /// Тело запроса, используемого для инициализации.
        /// </summary>
        [ConfigurationKeyName("body")]
        public string Body { get; set; } = string.Empty;

        /// <summary>
        /// Ссылка для инициализации.
        /// </summary>
        [ConfigurationKeyName("url")]
        public Uri InitializationUri { get; set; } = default!;
    }
}
