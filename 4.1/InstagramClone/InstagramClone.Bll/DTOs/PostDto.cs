namespace InstagramClone.Bll.DTOs;

public class PostDto : PostCreateDto
{
    public AccountDto? Account { get; set; }
    public List<CommentDto>? Comments { get; set; }
}