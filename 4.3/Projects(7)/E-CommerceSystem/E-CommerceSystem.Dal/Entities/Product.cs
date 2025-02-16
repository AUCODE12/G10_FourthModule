namespace E_CommerceSystem.Dal.Entities;

public class Product
{
    public long ProductId { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public double Stock { get; set; }

    public long CategoryId { get; set; }
    public Category Category { get; set; }

    public ICollection<CartProduct> CartProducts { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; }

    public ICollection<Order> Orders { get; set; }
    public ICollection<Review> Reviews { get; set; }
}
