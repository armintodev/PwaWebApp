using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pwa.Domain.Account;
using Pwa.Domain.Product;
using Pwa.Infrastructure.EfCore.Configuration;

namespace Pwa.Infrastructure.EfCore
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var assembly = typeof(UserConfiguration).Assembly;
            builder.ApplyConfigurationsFromAssembly(assembly);
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SourceSite> SourceSites { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<WebApplication> WebApplications { get; set; }
    }
}
