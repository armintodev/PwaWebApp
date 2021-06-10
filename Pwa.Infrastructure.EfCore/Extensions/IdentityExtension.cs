using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Pwa.Domain.Account;

namespace Pwa.Infrastructure.EfCore.Extensions
{
    internal static class IdentityExtension
    {
        public static void AddIdentityApplication(this IServiceCollection service)
        {
            service.AddIdentity<User, Role>(_ =>
              {
                  _.Password.RequireNonAlphanumeric = false;
                  _.Password.RequireUppercase = false;
                  _.SignIn.RequireConfirmedEmail = false;
                  _.SignIn.RequireConfirmedPhoneNumber = true;
                  _.SignIn.RequireConfirmedAccount = true;
              }).AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
