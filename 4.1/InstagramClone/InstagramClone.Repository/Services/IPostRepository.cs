using InstagramClone.Dal.Entities;

namespace InstagramClone.Repository.Services;

public interface IPostRepository
{
    Task<long> AddPost(Post post);

    Task UpdatePost(Post post);
    
    Task DeletePost(long id);

    Task<Post> GetPostById(long id);

    Task<List<Post>> GetAllPosts();
}