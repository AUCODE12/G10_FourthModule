using E_CommerceSystem.Dal.Enums;

namespace E_CommerceSystem.Dal.Entities;

public class Order
{
    public long OrderId { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public DateTime OrderDate { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public ICollection<OrderProduct> OrderProducts { get; set; }
    public ICollection<Payment> Payments { get; set; }
}
