namespace InstagramClone.Bll.DTOs;

public class AccountDto : AccountCreateDto
{
    public List<AccountDto>? Folleowers { get; set; }
    public List<AccountDto>? Following { get; set; }
    public List<PostDto>? Posts { get; set; }
    public List<CommentDto>? Comments { get; set; }
}
