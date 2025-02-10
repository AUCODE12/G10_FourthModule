namespace InstagramClone.Bll.DTOs;

public class CommentDto
{
    public long? CommentId { get; set; }
    public string ContentText { get; set; }
    public DateTime WritingTime { get; set; }
    public long AccountId { get; set; }
    public AccountDto? Account { get; set; }
    public long PostId { get; set; }
    public PostDto? Post { get; set; }
    public long? ReplyToCommentId { get; set; }
    public CommentDto? ReplyToComment { get; set; }
    public List<CommentDto>? Replies { get; set; }
}