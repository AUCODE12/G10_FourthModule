using Instagram.Dal.Entities;

namespace Instagram.Repository.Services;

public interface IPostRepository
{
    Task<long> AddPost(Post post);

    Task<Post> GetPostById(long id);

    Task<List<Post>> GetAllPosts();
    Task<bool> PostExistsAsync(long value);
}