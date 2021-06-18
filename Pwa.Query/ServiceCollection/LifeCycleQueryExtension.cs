using Microsoft.Extensions.DependencyInjection;
using Pwa.Query.Contracts.Category;
using Pwa.Query.Contracts.User;
using Pwa.Query.Contracts.WebApp;
using Pwa.Query.Queries;

namespace Pwa.Query.ServiceCollection
{
    public static class LifeCycleQueryExtension
    {
        public static void AddQueryService(this IServiceCollection service)
        {
            service.AddScoped<IWebAppQuery, WebAppQuery>();
            service.AddScoped<ICategoryQuery, CategoryQuery>();
            service.AddScoped<IUserQuery, UserQuery>();
        }
    }
}
