using Microsoft.Extensions.Caching.StackExchangeRedis;
using RedisForDummies.Api.Settings;

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
        private static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(o => ConfigureRedis(o, configuration));

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