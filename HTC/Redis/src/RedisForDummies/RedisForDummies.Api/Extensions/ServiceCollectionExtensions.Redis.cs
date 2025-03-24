using Microsoft.Extensions.Caching.StackExchangeRedis;
using RedisForDummies.Api.Settings;
using RedisForDummies.Application.Caches.Redis;
using RedisForDummies.Infrastructure.Caches.Redis;

namespace RedisForDummies.Api.Extensions
{
    /// <summary>
    /// ������-���������� ��� <see cref="IServiceCollection"/> ��� ������ � Redis'��.
    /// </summary>
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// �������� Redis.
        /// </summary>
        /// <param name="services">��������� ��������.</param>
        /// <param name="configuration">������������ <see cref="IConfiguration"/>.</param>
        /// <returns>��������� �������� � ����������� Redis'��.</returns>
        public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRedisCache(o => ConfigureRedis(o, configuration));

            return services;
        }

        /// <summary>
        /// �������� ���, ��������������� Redis'��.
        /// </summary>
        /// <param name="services">��������� ��������.</param>
        /// <param name="setupAction">�������� ��� ��������� ����.</param>
        /// <returns>��������� �������� � ����������� ����� Redis'�.</returns>
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
        /// ��������� Redis.
        /// </summary>
        /// <param name="options">��������� ��� Redis'�.</param>
        /// <param name="configuration">������������ <see cref="IConfiguration"/>.</param>
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