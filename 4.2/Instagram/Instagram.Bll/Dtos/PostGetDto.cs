using Instagram.Dal.Entities;

namespace Instagram.Bll.Dtos;

public class PostGetDto : PostCreateDto
{
    public DateTime CreatedTime { get; set; }
    public Account Account { get; set; }
    public List<Comment> Comments { get; set; }
}
