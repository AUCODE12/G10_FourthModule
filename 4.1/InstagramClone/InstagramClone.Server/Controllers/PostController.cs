using InstagramClone.Bll.DTOs;
using InstagramClone.Bll.Services;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.Server.Controllers;

[Route("api/post")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpPost("add")]
    public async Task<long> PostPost(PostDto post)
    {
        return await _postService.AddPost(post);
    }

    [HttpPut("edit")]
    public async Task PutPost(PostDto post)
    {
        await _postService.UpdatePost(post);
    }

    [HttpDelete("delete/{id}")]
    public async Task DeletePost(long id)
    {
        await _postService.DeletePost(id);
    }

    [HttpGet("get/{id}")]
    public async Task<PostDto> GetPostById(long id)
    {
        return await _postService.GetPostById(id);
    }

    [HttpGet("getAll")]
    public async Task<List<PostDto>> GetAllPosts()
    {
        return await _postService.GetAllPosts();
    }
}
