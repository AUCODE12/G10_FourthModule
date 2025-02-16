using EventManagementSystem.Dal.Enums;

namespace EventManagementSystem.Dal.Entities;

public class Payment
{
    public long PaymentId { get; set; }
    public decimal Amount { get; set; }
    public PaymentStatus PaymentStatus { get; set; }

    public long TicketId { get; set; }
    public Ticket Ticket { get; set; }
}
