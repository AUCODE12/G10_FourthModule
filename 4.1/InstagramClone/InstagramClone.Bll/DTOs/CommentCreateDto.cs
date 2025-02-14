namespace InstagramClone.Bll.DTOs;

public class CommentCreateDto
{
    public string ContentText { get; set; }
    public long AccountId { get; set; }
    public long PostId { get; set; }
    public long? ReplyToCommentId { get; set; }
}
