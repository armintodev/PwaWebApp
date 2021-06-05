using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pwa.Domain.Account;

namespace Pwa.Infrastructure.EfCore.Configuration
{
    public class StatisticConfiguration : IEntityTypeConfiguration<Statistic>
    {
        public void Configure(EntityTypeBuilder<Statistic> builder)
        {
            builder.ToTable("Statistics");
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Browser)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(_ => _.Device)
                .HasMaxLength(250);

            builder.Property(_ => _.Os)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(_ => _.Version)
                .HasMaxLength(500)
                .IsRequired();

            builder.HasOne(_ => _.Developer)
                .WithMany(_ => _.Statistics)
                .HasForeignKey(_ => _.DeveloperId);
        }
    }
}
