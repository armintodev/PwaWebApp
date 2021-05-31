using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pwa.Domain.Product;

namespace Pwa.Infrastructure.EfCore.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Title)
                .HasMaxLength(500)
                .IsRequired();

            builder.HasMany(_ => _.WebApplications)
               .WithOne(_ => _.Category)
               .HasForeignKey(_ => _.CategoryId);
        }
    }
}
