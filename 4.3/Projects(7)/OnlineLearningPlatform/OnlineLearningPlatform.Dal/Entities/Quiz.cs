namespace OnlineLearningPlatform.Dal.Entities;

public class Quiz
{
    public long QuizId { get; set; }
    public string Title { get; set; }
    public string Question { get; set; }

    public long LessonId { get; set; }
    public Lesson Lesson { get; set; }
}