using Microsoft.Extensions.DependencyInjection;
using Pwa.Application;
using Pwa.Application.Contracts.Account.Developer;
using Pwa.Application.Contracts.Account.Role;
using Pwa.Application.Contracts.Account.Statistic;
using Pwa.Application.Contracts.Account.User;
using Pwa.Application.Contracts.Product.Category;
using Pwa.Application.Contracts.Product.Comment;
using Pwa.Application.Contracts.Product.Ticket;
using Pwa.Application.Contracts.Product.WebApplication;
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
            service.AddScoped<IRoleApplication, RoleApplication>();

            service.AddScoped<IStatisticRepository, StatisticRepository>();
            service.AddScoped<IStatisticApplication, StatisticApplication>();

            service.AddScoped<IPictureRepository, PictureRepository>();

            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IUserApplication, UserApplication>();

            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<ICategoryApplication, CategoryApplication>();

            service.AddScoped<ICommentRepository, CommentRepository>();
            service.AddScoped<ICommentApplication, CommentApplication>();

            service.AddScoped<ISourceSiteRepository, SourceSiteRepository>();

            service.AddScoped<ITicketRepository, TicketRepository>();
            service.AddScoped<ITicketApplication, TicketApplication>();

            service.AddScoped<IWebApplicationRepository, WebApplicationRepository>();
            service.AddScoped<IWebApplicationApplication, WebApplicationApplication>();
        }
    }
}
