namespace InstagramClone.Dal.Entities;

public class Comment
{
    public long CommentId { get; set; }
    public string ContentText { get; set; }
    public DateTime WritingTime { get; set; }
    public long AccountId { get; set; }
    public Account Account { get; set; }
    public long PostId { get; set; }
    public Post Post { get; set; }
    public long? ReplyToCommentId { get; set; }
    public Comment ReplyToComment { get; set; }
    public List<Comment> Replies { get; set; }
}

