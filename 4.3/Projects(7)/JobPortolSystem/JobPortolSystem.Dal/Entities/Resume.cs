namespace JobPortolSystem.Dal.Entities;

public class Resume
{
    public long ResumeId { get; set; }
    public string FilePath { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}
