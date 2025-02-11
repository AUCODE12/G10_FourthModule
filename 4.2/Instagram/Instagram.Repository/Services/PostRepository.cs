using Instagram.Dal;
using Instagram.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Repository.Services;

public class PostRepository : IPostRepository
{
    private readonly MainContext MainContext;

    public PostRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<long> AddPost(Post post)
    {
        await MainContext.AddAsync(post);
        await MainContext.SaveChangesAsync();
        return post.AccountId;
    }

    public async Task<List<Post>> GetAllPosts()
    {
        return await MainContext.Posts.ToListAsync();
    }

    public Task<Post> GetPostById(long id)
    {
        var post = MainContext.Posts.FirstOrDefaultAsync(p => p.PostId == id);
        if (post == null) throw new Exception("not found");
        return post;
    }

    public async Task<bool> PostExistsAsync(long id)
    {
        var res = await MainContext.Posts.AnyAsync(c => c.PostId == id);

        return res;
    }
}
