using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.Dal.Entities;

namespace OnlineLearningPlatform.Dal.EntityConfigurations;

public class QuizConfiguration : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        builder.ToTable("Quiz");

        builder.HasKey(c => c.QuizId);

        builder.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(50);
    }
}
