using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pwa.Domain.Product;

namespace Pwa.Infrastructure.EfCore.Configuration
{
    class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Description)
                .HasMaxLength(1500)
                .IsRequired();

            builder.HasOne(o => o.User)
                .WithMany(m => m.Comments)
                .HasForeignKey(f => f.UserId);

            builder.HasOne(o => o.WebApplication)
                .WithMany(m => m.Comments)
                .HasForeignKey(f => f.WebApplicationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
