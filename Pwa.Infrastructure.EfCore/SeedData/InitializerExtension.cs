using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Pwa.Infrastructure.EfCore.SeedData
{
    public static class InitializerExtension
    {
        public static async Task<IApplicationBuilder> InitializeDataBase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>(); //Service locator

            //Dos not use Migrations, just Create Database with latest changes
            //dbContext.Database.EnsureCreated();
            //Applies any pending migrations for the context to the database like (Update-Database)
            dbContext.Database.Migrate();

            var dataInitializers = scope.ServiceProvider.GetServices<IDataInitializer>();
            foreach (var dataInitializer in dataInitializers)
                await dataInitializer.Initialize();

            return app;
        }

        public static void AddInitializerDatabase(this IServiceCollection service)
        {
            service.AddScoped<IDataInitializer, RoleInitializer>();
            service.AddScoped<IDataInitializer, CategoryInitializer>();
            service.AddScoped<IDataInitializer, UserInitializer>();
            service.AddScoped<IDataInitializer, DeveloperInitializer>();
        }
    }
}
