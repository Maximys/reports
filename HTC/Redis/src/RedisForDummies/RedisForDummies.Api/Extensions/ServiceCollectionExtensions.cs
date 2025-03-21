using Apache.Extensions.Caching.Ignite;
using Apache.Ignite;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using RedisForDummies.Api.Settings;
using RedisForDummies.Application.Providers.Counters;
using RedisForDummies.Infrastructure.Providers.Counters;

namespace RedisForDummies.Api.Extensions
{
    /// <summary>
    /// Методы-расширения для <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Добавить сервисы приложения.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddApplicationServices()
                .AddApacheIgnite(configuration)
                /*.AddRedis(configuration)*/;

            return services;
        }

        /// <summary>
        /// Добавить сервисы из слоя Application.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ICounterService, CounterService>();

            return services;
        }

        /// <summary>
        /// Добавить Apache Ignite.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <param name="configuration">Конфигурация <see cref="IConfiguration"/>.</param>
        private static IServiceCollection AddApacheIgnite(this IServiceCollection services, IConfiguration configuration)
        {
            ApacheIgniteSettings apacheIgniteSettings;

            apacheIgniteSettings = configuration.GetRequiredSection(nameof(ApacheIgniteSettings))
                .Get<ApacheIgniteSettings>()!;

            services.AddIgniteClientGroup(new IgniteClientGroupConfiguration
            {
                ClientConfiguration = new IgniteClientConfiguration(apacheIgniteSettings.Endpoints)
            })
            .AddIgniteDistributedCache(options => options.CacheKeyPrefix = "prefix");

            return services;
        }

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
                .Get<RedisSettings>();

            options.Configuration = redisSettings.Configuration;
            options.InstanceName = redisSettings.InstanceName;
        }
    }
}
