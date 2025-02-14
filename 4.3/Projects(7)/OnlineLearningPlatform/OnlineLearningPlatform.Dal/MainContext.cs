using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.Dal.Entities;
using OnlineLearningPlatform.Dal.EntityConfigurations;

namespace OnlineLearningPlatform.Dal;

public class MainContext : DbContext
{
    public DbSet<Enrollment> Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }

    public MainContext(DbContextOptions<MainContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new EnrollmentConfiguration());
        modelBuilder.ApplyConfiguration(new LessonConfiguration());
        modelBuilder.ApplyConfiguration(new QuizConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}
