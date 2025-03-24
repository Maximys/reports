using Microsoft.Extensions.Caching.StackExchangeRedis;
using RedisForDummies.Api.Settings;

namespace RedisForDummies.Api.Extensions
{
    /// <summary>
    /// Методы-расширения для <see cref="IServiceCollection"/> для работы с Redis'ом.
    /// </summary>
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Добавить Redis.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <param name="configuration">Конфигурация <see cref="IConfiguration"/>.</param>
        private static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(o => ConfigureRedis(o, configuration));

            return services;
        }

        /// <summary>
        /// Настроить Redis.
        /// </summary>
        /// <param name="options">Настройки для Redis'а.</param>
        /// <param name="configuration">Конфигурация <see cref="IConfiguration"/>.</param>
        private static void ConfigureRedis(RedisCacheOptions options, IConfiguration configuration)
        {
            RedisSettings redisSettings;

            redisSettings = configuration.GetSection(nameof(RedisSettings))
                .Get<RedisSettings>()!;

            options.Configuration = redisSettings.Configuration;
            options.InstanceName = redisSettings.InstanceName;
        }
    }
}