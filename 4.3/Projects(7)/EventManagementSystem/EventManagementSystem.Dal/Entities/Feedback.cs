using Microsoft.Extensions.Logging;

namespace EventManagementSystem.Dal.Entities;

public class Feedback
{
    public long FeedbackId { get; set; }
    public double Rating { get; set; }
    public string Comment { get; set; }

    public long EventId { get; set; }
    public Event Event { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}
