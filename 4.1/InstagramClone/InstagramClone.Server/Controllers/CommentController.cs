using InstagramClone.Bll.DTOs;
using InstagramClone.Bll.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstagramClone.Server.Controllers;

[Route("api/comment")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost("add")]
    public async Task<long> PostComment(CommentCreateDto comment)
    {
        return await _commentService.AddComment(comment);
    }

    [HttpDelete("delete")]
    public async Task DeleteComment(long id)
    {
        await _commentService.DeleteComment(id);
    }

    [HttpPut("etid")]
    public async Task PutComment(CommentCreateDto comment)
    {
        await _commentService.UpdateComment(comment);
    }

    [HttpGet("get/{id}")]
    public async Task<CommentDto> GetCommentById(long id)
    {
        return await _commentService.GetCommentById(id);
    }

    [HttpGet("getAll")]
    public async Task<List<CommentDto>> GetAllComments()
    {
        return await _commentService.GetAllComments();
    }
}
