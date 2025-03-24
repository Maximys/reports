using System.Net.Mime;
using System.Text;
using Apache.Extensions.Caching.Ignite;
using Apache.Ignite;
using RedisForDummies.Api.Settings.ApacheIgnite;

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
            .AddIgniteDistributedCache(options => options.CacheKeyPrefix = "prefix");

            InitApacheIgniteCluster(apacheIgniteSettings);

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