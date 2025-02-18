namespace E_CommerceSystem.Dal.Entities;

public class OrderProduct
{
    public long OrderProductId { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public long OrderId { get; set; }
    public Order Order { get; set; }

    public long ProductId { get; set; }
    public Product Product { get; set; }
}
