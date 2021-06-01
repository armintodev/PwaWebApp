using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Pwa.Domain.Account;

namespace Pwa.Infrastructure.EfCore.Extensions
{
    internal static class IdentityExtension
    {
        public static void AddIdentityApplication(this IServiceCollection service)
        {
            service.AddIdentityCore<User>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            service.AddIdentityCore<Developer>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            service.Configure<IdentityOptions>(_ =>
            {
                _.User.RequireUniqueEmail = true;
                _.SignIn.RequireConfirmedPhoneNumber = true;
                _.SignIn.RequireConfirmedAccount = true;
            });
        }
    }
}
