namespace InstagramClone.Dal.Entities;

public class Account
{
    public long AccountId { get; set; }
    public string Username { get; set; }
    public string Bio { get; set; }
    public List<Account> Folleowers { get; set; }
    public List<Account> Following {  get; set; }
    public List<Post> Posts { get; set; }
    public List<Comment> Comments { get; set; }
}
