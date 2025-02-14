namespace OnlineLearningPlatform.Dal.Entities;

public class Course
{
    public long CourseId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public long InstructorId { get; set; }
    public User Instructor { get; set; }

    public ICollection<Lesson> Lessons { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; }
}
