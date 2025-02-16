using EventManagementSystem.Dal.Enums;
using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.Dal.Entities;

public class User
{
    public long UserId { get; set; }
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public UserRole UserRole { get; set; }

    public ICollection<Event> Events { get; set; }

    public ICollection<Ticket> Tickets { get; set; }

    public ICollection<Feedback> Feedbacks { get; set; }
}
