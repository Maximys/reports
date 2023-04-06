using SimpleWebAPI.Application;
using SimpleWebAPI.Application.Users;
using SimpleWebAPI.Domain.Users;
using SimpleWebAPI.Infrastructure.Repositories.Users;
using System.Reflection;

namespace SimpleWebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddAutoMapper(Assembly.GetAssembly(typeof(IApplicationAssembly)))
                .AddInfrastructureEnvironment()
                .AddApplicationEnvironment();

            return services;
        }

        private static IServiceCollection AddApplicationEnvironment(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            return services;
        }

        private static IServiceCollection AddInfrastructureEnvironment(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
