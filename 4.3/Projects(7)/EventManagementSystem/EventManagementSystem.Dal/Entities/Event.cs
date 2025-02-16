namespace EventManagementSystem.Dal.Entities;

public class Event
{
    public long EventId { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime Date { get; set; }

    public long OrganizerId { get; set; }
    public User Organizer { get; set; }

    public ICollection<Ticket> Tickets { get; set; }

    public ICollection<Feedback> Feedbacks { get; set; }
}

