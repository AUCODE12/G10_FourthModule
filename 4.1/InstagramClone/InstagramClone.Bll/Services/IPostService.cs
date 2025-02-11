using InstagramClone.Bll.DTOs;

namespace InstagramClone.Bll.Services;

public interface IPostService
{
    Task<long> AddPost(PostCreateDto post);

    Task UpdatePost(PostCreateDto post);

    Task DeletePost(long id);

    Task<PostDto> GetPostById(long id);

    Task<List<PostDto>> GetAllPosts();
}