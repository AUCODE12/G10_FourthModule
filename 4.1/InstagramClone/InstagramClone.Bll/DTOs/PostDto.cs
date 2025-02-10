namespace InstagramClone.Bll.DTOs;

public class PostDto
{
    public long? PostId { get; set; }
    public string PostType { get; set; }
    public DateTime SetTime { get; set; }
    public long AccountId { get; set; }
    public AccountDto? Account { get; set; }
    public List<CommentDto>? Comments { get; set; }
}