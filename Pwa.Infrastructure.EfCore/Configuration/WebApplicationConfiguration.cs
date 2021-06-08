using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pwa.Domain.Product;

namespace Pwa.Infrastructure.EfCore.Configuration
{
    public class WebApplicationConfiguration : IEntityTypeConfiguration<WebApplication>
    {
        public void Configure(EntityTypeBuilder<WebApplication> builder)
        {
            builder.ToTable("WebApplications");
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Name)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(_ => _.Description)
                .HasMaxLength(5000)
                .IsRequired();

            builder.Property(_ => _.WebSiteAddress)
                .HasMaxLength(500)
                .IsRequired();

            builder.HasOne(_ => _.Category)
                .WithMany(_ => _.WebApplications)
                .HasForeignKey(_ => _.CategoryId);

            builder.HasOne(_ => _.Developer)
                .WithMany(_ => _.WebApplications)
                .HasForeignKey(_ => _.DeveloperId);

            builder.HasMany(_ => _.Comments)
                .WithOne(_ => _.WebApplication)
                .HasForeignKey(_ => _.WebApplicationId);

            builder.HasMany(_ => _.Pictures)
                .WithOne(_ => _.WebApplication)
                .HasForeignKey(_ => _.WebApplicationId);
        }
    }
}
