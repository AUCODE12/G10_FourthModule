namespace E_CommerceSystem.Dal.Entities;

public class Review
{
    public long ReviewId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public long ProductId { get; set; }
    public Product Product { get; set; }
}
