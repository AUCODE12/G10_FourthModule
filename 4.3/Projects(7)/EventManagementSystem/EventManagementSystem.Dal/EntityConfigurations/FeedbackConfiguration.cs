using EventManagementSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManagementSystem.Dal.EntityConfigurations;

public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder.ToTable("Feedback");

        builder.HasKey(u => u.FeedbackId);

        builder.Property(u => u.Comment)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(u => u.Rating)
            .IsRequired();
    }
}
