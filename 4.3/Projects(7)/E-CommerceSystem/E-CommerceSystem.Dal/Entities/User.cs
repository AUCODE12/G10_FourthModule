using E_CommerceSystem.Dal.Enums;

namespace E_CommerceSystem.Dal.Entities;

public class User
{
    public long UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }

    public long? CartId { get; set; }
    public Cart? Cart { get; set; }     

    public ICollection<Order> Orders { get; set; }

    public ICollection<Review> Reviews { get; set; }
}
