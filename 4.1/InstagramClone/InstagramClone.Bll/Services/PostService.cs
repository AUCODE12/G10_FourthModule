using InstagramClone.Bll.DTOs;
using InstagramClone.Dal.Entities;
using InstagramClone.Repository.Services;

namespace InstagramClone.Bll.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;

    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<long> AddPost(PostDto post)
    {
        return await _postRepository.AddPost(ConvertToPostEntity(post));
    }

    public async Task DeletePost(long id)
    {
        await _postRepository.DeletePost(id);
    }

    public async Task<List<PostDto>> GetAllPosts()
    {
        var posts = await _postRepository.GetAllPosts();
        return posts.Select(p => ConvertToDto(p)).ToList();
    }

    public async Task<PostDto> GetPostById(long id)
    {
        return ConvertToDto(await _postRepository.GetPostById(id));
    }

    public async Task UpdatePost(PostDto post)
    {
        await _postRepository.UpdatePost(ConvertToPostEntity(post));
    }

    private Post ConvertToPostEntity(PostDto postDto)
    {
        return new Post
        {
            AccountId = postDto.AccountId,
            SetTime = postDto.SetTime,
            PostType = postDto.PostType,
        };
    }

    private PostDto ConvertToDto(Post post)
    {
        return new PostDto
        {
            PostType = post.PostType,
            PostId = post.PostId,
            AccountId = post.AccountId,
            SetTime = post.SetTime, 
        };
    }
}
