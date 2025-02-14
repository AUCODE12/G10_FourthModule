using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.Dal.Entities;

namespace OnlineLearningPlatform.Dal.EntityConfigurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("Lesson");

        builder.HasKey(c => c.LessonId);

        builder.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.VideoURL)
            .IsRequired();

        builder.HasMany(c => c.Quizzes)
            .WithOne(c => c.Lesson)
            .HasForeignKey(c => c.LessonId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
