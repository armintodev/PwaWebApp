using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pwa.Domain.Product;

namespace Pwa.Infrastructure.EfCore.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Tickets");
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Title)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(_ => _.Description)
                .IsRequired();

            builder.HasOne(_ => _.Developer)
                .WithMany(_ => _.Tickets)
                .HasForeignKey(_ => _.DeveloperId);
        }
    }
}
