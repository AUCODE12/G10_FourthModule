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

    public async Task<long> AddPost(PostCreateDto post)
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

    public async Task UpdatePost(PostCreateDto post)
    {
        await _postRepository.UpdatePost(ConvertToPostEntity(post));
    }

    private Post ConvertToPostEntity(PostCreateDto postDto)
    {
        return new Post
        {
            PostId = postDto.PostId ?? 0,
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
            Account = post.Account != null ? new AccountDto
            {
                AccountId = post.Account.AccountId,
                Bio = post.Account.Bio,
                Username = post.Account.Username,
            } : null,
            Comments = post.Comments?.Select(c => new CommentDto
            {
                CommentId = c.CommentId,
                ContentText = c.ContentText,
                WritingTime = c.WritingTime,
                AccountId = c.AccountId,
                PostId = c.PostId,
                ReplyToCommentId = c.ReplyToCommentId,
            }).ToList(),
        };
    }
}
