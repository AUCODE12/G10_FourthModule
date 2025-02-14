namespace OnlineLearningPlatform.Dal.Entities;

public class Lesson
{
    public long LessonId { get; set; }
    public string Title { get; set; }
    public string VideoURL { get; set; }

    public long CourseId { get; set; }
    public Course Course { get; set; }

    public ICollection<Quiz> Quizzes { get; set; }
}
