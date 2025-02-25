namespace JobPortolSystem.Dal.Entities;

public class Interview
{
    public long InterviewId { get; set; }
    public DateTime Date { get; set; }
    public InterviewStatus Status { get; set; }

    public long AplicationId { get; set; }
    public Aplication Aplication { get; set; }
}
