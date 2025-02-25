namespace JobPortolSystem.Dal.Entities;

public class Aplication
{
    public long AplicationId { get; set; }
    public DateTime AppliedDate { get; set; }
    public ApplicationStatus Status { get; set; }

    public long JobId { get; set; }
    public Job Job { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}
