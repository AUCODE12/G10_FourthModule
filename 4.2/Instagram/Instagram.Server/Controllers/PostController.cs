using Instagram.Bll.Dtos;
using Instagram.Bll.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Server.Controllers;

[Route("api/post")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    public async Task<long> AddPost(PostCreateDto post)
    {
        return await _postService.AddPost(post);
    }

    public async Task<PostGetDto> GetPostById(long id)
    {
        return await _postService.GetPostById(id);
    }

    public async Task<List<PostGetDto>> GetAllPosts()
    {
        return await _postService.GetAllPosts();
    }
}
