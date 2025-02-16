namespace E_CommerceSystem.Dal.Entities;

public class OrderProduct
{
    public long OrderId { get; set; }
    public Order Order { get; set; }

    public long ProductId { get; set; }
    public Product Product { get; set; }

    public int Quentity { get; set; }
    public double Price { get; set; }
}
