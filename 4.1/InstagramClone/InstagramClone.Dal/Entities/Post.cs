namespace InstagramClone.Dal.Entities;

public class Post
{
    public long PostId { get; set; }
    public string PostType { get; set; }
    public DateTime SetTime { get; set; }
    public long AccountId { get; set; }
    public Account Account { get; set; }
    public List<Comment> Comments { get; set; }
}
