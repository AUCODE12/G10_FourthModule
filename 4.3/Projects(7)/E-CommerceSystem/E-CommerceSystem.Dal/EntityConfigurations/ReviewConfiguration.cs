using E_CommerceSystem.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_CommerceSystem.Dal.EntityConfigurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Review");

        builder.HasKey(e => e.ReviewId);

        builder.Property(e => e.Comment)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.Rating)
            .IsRequired();
    }
}
