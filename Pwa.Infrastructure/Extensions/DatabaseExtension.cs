using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Pwa.Infrastructure.EfCore.Extensions
{
    internal static class DatabaseExtension
    {
        public static void AddDatabaseExtension(this IServiceCollection service, string connectionString)
        {
            service.AddDbContextPool<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
        }
    }
}
