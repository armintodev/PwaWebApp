using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pwa.Domain.Product;

namespace Pwa.Infrastructure.EfCore.Configuration
{
    public class SourceSiteConfiguration : IEntityTypeConfiguration<SourceSite>
    {
        public void Configure(EntityTypeBuilder<SourceSite> builder)
        {
            builder.ToTable("SourceSites");
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Name)
                 .HasMaxLength(250)
                 .IsRequired();

            builder.Property(_ => _.Description)
                .HasMaxLength(5000)
                .IsRequired();
            builder.Property(_ => _.Address)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(_ => _.Icons)
                .HasMaxLength(1000)
                .IsRequired();

            //builder.HasOne(_ => _.User)
            //    .WithMany(_ => _.SourceSites)
            //    .HasForeignKey(_ => _.UserId);
        }
    }
}
