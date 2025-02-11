using InstagramClone.Dal;
using InstagramClone.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstagramClone.Repository.Services;

public class PostRepository : IPostRepository
{
    private readonly MainContext _mainContext;

    public PostRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<long> AddPost(Post post)
    {
        await _mainContext.Posts.AddAsync(post);
        await _mainContext.SaveChangesAsync();
        return post.PostId;
    }

    public async Task DeletePost(long id)
    {
        var postFind = await GetPostById(id);
        _mainContext.Posts.Remove(postFind);
        await _mainContext.SaveChangesAsync();
    }

    public async Task<List<Post>> GetAllPosts()
    {
        return await _mainContext.Posts.ToListAsync();
    }

    public async Task<Post> GetPostById(long id)
    {
        var post = await _mainContext.Posts.FindAsync(id);
        return post ?? throw new Exception("Not Found");
    }

    public async Task UpdatePost(Post post)
    {
        var postFind = await GetPostById(post.PostId);
        postFind.PostType = post.PostType;
        postFind.SetTime = post.SetTime;
        await _mainContext.SaveChangesAsync();
    }
}
