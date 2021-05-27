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

            builder.Property(_ => _.PhoneNumber)
               .HasMaxLength(20)
               .IsRequired();

            builder.Property(_ => _.Email)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(_ => _.UserName)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(_ => _.FullName)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(_ => _.Status)
                .IsRequired();

            builder.HasOne(_ => _.Statistic)
                .WithMany(_ => _.Developers)
                .HasForeignKey(_ => _.StatisticId);

            builder.HasOne(_ => _.Address)
                .WithMany()
                .HasForeignKey(_ => _.AddressId);

            builder.HasMany(_ => _.WebApplications)
                .WithOne(_ => _.Developer)
                .HasForeignKey(_ => _.DeveloperId);

            builder.HasMany(_ => _.Tickets)
                .WithOne(_ => _.Developer)
                .HasForeignKey(_ => _.DeveloperId);
        }
    }
}
