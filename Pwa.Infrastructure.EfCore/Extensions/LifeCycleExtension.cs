using Microsoft.Extensions.DependencyInjection;
using Pwa.Application;
using Pwa.Application.Contracts.Account.Developer;
using Pwa.Application.Contracts.Account.Statistic;
using Pwa.Domain.Account;
using Pwa.Domain.Product;
using Pwa.Infrastructure.EfCore.Repositories;

namespace Pwa.Infrastructure.EfCore.Extensions
{
    internal static class LifeCycleExtension
    {
        public static void AddLifeCycleApplication(this IServiceCollection service)
        {
            service.AddScoped<IDeveloperRepository, DeveloperRepository>();
            service.AddScoped<IDeveloperApplication, DeveloperApplication>();

            service.AddScoped<IRoleRepository, RoleRepository>();

            service.AddScoped<IStatisticRepository, StatisticRepository>();
            service.AddScoped<IStatisticApplication, StatisticApplication>();

            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<ICommentRepository, CommentRepository>();
            service.AddScoped<ISourceSiteRepository, SourceSiteRepository>();
            service.AddScoped<ITicketRepository, TicketRepository>();
            service.AddScoped<IWebApplicationRepository, WebApplicationRepository>();
        }
    }
}
