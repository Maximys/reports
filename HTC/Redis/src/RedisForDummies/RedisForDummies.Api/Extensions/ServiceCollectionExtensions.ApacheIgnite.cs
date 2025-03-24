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
    /// ������-���������� ��� <see cref="IServiceCollection"/> ��� ������ � Apache Ignite.
    /// </summary>
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// �������� Apache Ignite.
        /// </summary>
        /// <param name="services">��������� ��������.</param>
        /// <param name="configuration">������������ <see cref="IConfiguration"/>.</param>
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
        /// �������� ���, ��������������� Apache Ignite'��.
        /// </summary>
        /// <param name="services">��������� ��������.</param>
        /// <param name="setupAction">�������� ��� ��������� ����.</param>
        /// <returns>��������� �������� � ����������� ����� Apache Ignite'�.</returns>
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
        /// ���������������� ������� Apache Ignite.
        /// </summary>
        /// <param name="apacheIgniteSettings">��������� ��� ������ � Apache Ignite.</param>
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
                        throw new InvalidOperationException("�� ������� ���������������� Apache Ignite");
                    }
                }
            }
        }
    }
}