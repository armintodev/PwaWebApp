using Microsoft.Extensions.DependencyInjection;

namespace Pwa.Infrastructure.EfCore.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddExtensionsApplication(this IServiceCollection services, string connectionString)
        {
            services.AddDatabaseExtension(connectionString);

            services.AddIdentityApplication();
        }
    }
}
