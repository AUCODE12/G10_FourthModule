namespace E_CommerceSystem.Dal.Entities;

public class Cart
{
    public long CartId { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public ICollection<CartProduct> CartProducts { get; set; }
}
