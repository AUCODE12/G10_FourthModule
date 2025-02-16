namespace E_CommerceSystem.Dal.Entities;

public class CartProduct
{
    public long CartId { get; set; }
    public Cart Cart { get; set; }

    public long ProductId { get; set; }
    public Product Product { get; set; }

    public int Quentity { get; set; }
}
