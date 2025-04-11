using System.Net.Mime;
using System.Text;
using Apache.Extensions.Caching.Ignite;
using Apache.Ignite;
using RedisForDummies.Api.Settings.ApacheIgnite;
using RedisForDummies.Application.Caches.ApacheIgnite;
using RedisForDummies.Infrastructure.Caches.ApacheIgnite;

namespace RedisForDummies.Api.Extensions
{
    /// <summary>
    /// Методы-расширения для <see cref="IServiceCollection"/> для работы с Apache Ignite.
    /// </summary>
    public static partial class ServiceCollectionExtensions
    {
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
            .AddApacheIgniteCache(options => options.CacheKeyPrefix = "prefix");

            InitApacheIgniteCluster(apacheIgniteSettings);

            return services;
        }

        /// <summary>
        /// Добавить Кэш, предоставляемый Apache Ignite'ом.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <param name="setupAction">Действие для настройки Кэша.</param>
        /// <returns>Коллекция сервисов с добавленным кэшем Apache Ignite'а.</returns>
        private static IServiceCollection AddApacheIgniteCache(this IServiceCollection services, Action<IgniteDistributedCacheOptions> setupAction)
        {
            ArgumentNullException.ThrowIfNull(services);
            ArgumentNullException.ThrowIfNull(setupAction);

            services.AddOptions();

            services.Configure(setupAction);
            services.Add(ServiceDescriptor.Singleton<IgniteDistributedCache, IgniteDistributedCache>());
            services.Add(ServiceDescriptor.Singleton<IApacheIgniteDistributedCache, ApacheIgniteDistributedCache>());

            return services;
        }

        /// <summary>
        /// Инициализировать кластер Apache Ignite.
        /// </summary>
        /// <param name="apacheIgniteSettings">Настройки для работы с Apache Ignite.</param>
        private static void InitApacheIgniteCluster(ApacheIgniteSettings apacheIgniteSettings)
        {
            using (HttpClient apacheIgniteClient = new HttpClient())
            {
                HttpRequestMessage webRequest = new HttpRequestMessage(HttpMethod.Post, apacheIgniteSettings.Initialization.InitializationUri)
                {
                    Content = new StringContent(apacheIgniteSettings.Initialization.Body, Encoding.UTF8, MediaTypeNames.Application.Json)
                };

                using (HttpResponseMessage webResponse = apacheIgniteClient.Send(webRequest))
                {
                    if (!webResponse.IsSuccessStatusCode)
                    {
                        throw new InvalidOperationException("Не удалось инициализировать Apache Ignite");
                    }
                }
            }
        }
    }
}