using EventManagementSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagementSystem.Dal.EntityConfigurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Ticket");

        builder.HasKey(u => u.TicketId);

        builder.Property(u => u.Price)
            .IsRequired();

        builder.Property(u => u.SeatNumber)
            .IsRequired();

        builder.HasIndex(u => u.SeatNumber)
            .IsUnique();

        builder.HasMany(u => u.Payments)
            .WithOne(u => u.Ticket)
            .HasForeignKey(u => u.TicketId);
    }
}
