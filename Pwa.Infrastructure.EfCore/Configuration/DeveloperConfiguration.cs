using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pwa.Domain.Account;

namespace Pwa.Infrastructure.EfCore.Configuration
{
    public class DeveloperConfiguration : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.ToTable("Developers");
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.NationalCode)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasOne(_ => _.User)
                .WithOne(_ => _.Developer)
                .HasForeignKey<User>(_ => _.Id);

            builder.Property(_ => _.Status)
                .IsRequired();

            builder.HasMany(_ => _.Statistics)
                .WithOne(_ => _.Developer)
                .HasForeignKey(_ => _.DeveloperId);

            builder.HasMany(_ => _.Tickets)
                .WithOne(_ => _.Developer)
                .HasForeignKey(_ => _.DeveloperId);
        }
    }
}
