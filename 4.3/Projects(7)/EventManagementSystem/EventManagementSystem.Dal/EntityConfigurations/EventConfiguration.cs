using EventManagementSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagementSystem.Dal.EntityConfigurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Event");

        builder.HasKey(u => u.EventId);

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.Location)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Date)
            .IsRequired();

        builder.HasMany(u => u.Tickets)
            .WithOne(u => u.Event)
            .HasForeignKey(u => u.EventId);

        builder.HasMany(u => u.Feedbacks)
            .WithOne(u => u.Event)
            .HasForeignKey(u => u.EventId);
    }
}
