namespace InstagramClone.Bll.DTOs;

public class AccountDto
{
    public long? AccountId { get; set; }
    public string Username { get; set; }
    public string Bio { get; set; }
    public List<AccountDto>? Folleowers { get; set; }
    public List<AccountDto>? Following { get; set; }
    public List<PostDto>? Posts { get; set; }
    public List<CommentDto>? Comments { get; set; }
}
