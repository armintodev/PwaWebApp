using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Pwa.Domain.Account;

namespace Pwa.Infrastructure.EfCore.Extensions
{
    internal static class IdentityExtension
    {
        public static void AddIdentityApplication(this IServiceCollection service)
        {
            service.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

            service.ConfigureApplicationCookie(_ =>
            {
                _.Cookie.Name = "AuthApplication";
                _.ExpireTimeSpan = TimeSpan.FromMinutes(20000);
                _.LoginPath = "/user/login";
                _.LogoutPath = "/user/logout";
                _.AccessDeniedPath = "/user/accessdenied";
                _.ClaimsIssuer = "DariaTechPwaArmin";
            });

            service.Configure<IdentityOptions>(_ =>
            {
                _.Password.RequireNonAlphanumeric = false;
                _.Password.RequireUppercase = false;
                _.SignIn.RequireConfirmedEmail = false;
                _.SignIn.RequireConfirmedPhoneNumber = true;
                _.SignIn.RequireConfirmedAccount = true;
            });
        }
    }
}
