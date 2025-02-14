namespace OnlineLearningPlatform.Dal.Entities;

public class Enrollment
{
    public long EnrollmentId { get; set; }
    public DateTime EnrollmentDate { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public long CourseId { get; set; }
    public Course Course { get; set; }
}
