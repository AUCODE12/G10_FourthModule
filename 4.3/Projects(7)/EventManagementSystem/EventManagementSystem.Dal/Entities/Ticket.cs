namespace EventManagementSystem.Dal.Entities;

public class Ticket
{
    public long TicketId { get; set; }
    public decimal Price { get; set; }
    public int SeatNumber { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public long EventId { get; set; }
    public Event Event { get; set; }

    public ICollection<Payment> Payments { get; set; }
}
