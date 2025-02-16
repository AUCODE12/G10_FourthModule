using E_CommerceSystem.Dal.Enums;

namespace E_CommerceSystem.Dal.Entities;

public class User
{
    public long UserId { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public UserRole UserRole { get; set; }

    public long CartId { get; set; }
    public Cart Cart { get; set; }     

    //public ICollection<Category> Categories { get; set; }
    public ICollection<Order> Orders { get; set; }
    //public ICollection<Product> Products { get; set; }
    public ICollection<Review> Reviews { get; set; }
}
