using E_CommerceSystem.Dal.Enums;

namespace E_CommerceSystem.Dal.Entities;

public class Payment
{
    public long PaymentId { get; set; }
    public double Amount { get; set; }
    public PaymentStatus PaymentStatus { get; set; }

    public long OrderId { get; set; }
    public Order Order { get; set; }

    public ICollection<Product> Products { get; set; }

}
