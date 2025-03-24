using RedisForDummies.Application.Providers.Counters;
using RedisForDummies.Infrastructure.Providers.Counters;

namespace RedisForDummies.Api.Extensions
{
    /// <summary>
    /// Методы-расширения для <see cref="IServiceCollection"/>.
    /// </summary>
    public static partial class ServiceCollectionExtensions
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
    }
}
