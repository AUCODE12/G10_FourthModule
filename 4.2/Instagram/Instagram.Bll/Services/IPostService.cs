using Instagram.Bll.Dtos;
using Instagram.Dal.Entities;

namespace Instagram.Bll.Services;

public interface IPostService
{
    Task<long> AddPost(PostCreateDto post);

    Task<PostGetDto> GetPostById(long id);

    Task<List<PostGetDto>> GetAllPosts();
}