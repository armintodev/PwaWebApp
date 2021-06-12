using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pwa.Domain.Account;

namespace Pwa.Infrastructure.EfCore.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(_ => _.Email)
                .HasMaxLength(500);

            builder.Property(_ => _.UserName)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(_ => _.Status)
                .IsRequired();

            builder.HasMany(_ => _.Comments)
                .WithOne(_ => _.User)
                .HasForeignKey(_ => _.UserId);
        }
    }
}
