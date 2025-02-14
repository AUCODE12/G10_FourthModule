namespace InstagramClone.Bll.DTOs;

public class CommentDto : CommentCreateDto
{
    public DateTime WritingTime { get; set; }
    public AccountDto? Account { get; set; }
    public PostDto? Post { get; set; }
    public CommentDto? ReplyToComment { get; set; }
    public List<CommentDto>? Replies { get; set; }
}