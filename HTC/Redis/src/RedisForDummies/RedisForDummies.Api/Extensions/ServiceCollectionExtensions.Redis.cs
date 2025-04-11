using Microsoft.Extensions.Caching.StackExchangeRedis;
using RedisForDummies.Api.Settings;
using RedisForDummies.Application.Caches.Redis;
using RedisForDummies.Infrastructure.Caches.Redis;

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
        /// <returns>Коллекция сервисов с добавленным Redis'ом.</returns>
        public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRedisCache(o => ConfigureRedis(o, configuration));

            return services;
        }

        /// <summary>
        /// Добавить Кэш, предоставляемый Redis'ом.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <param name="setupAction">Действие для настройки Кэша.</param>
        /// <returns>Коллекция сервисов с добавленным кэшем Redis'а.</returns>
        private static IServiceCollection AddRedisCache(this IServiceCollection services, Action<RedisCacheOptions> setupAction)
        {
            ArgumentNullException.ThrowIfNull(services);
            ArgumentNullException.ThrowIfNull(setupAction);

            services.AddOptions();

            services.Configure(setupAction);
            services.Add(ServiceDescriptor.Singleton<IRedisDistributedCache, RedisDistributedCache>());

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