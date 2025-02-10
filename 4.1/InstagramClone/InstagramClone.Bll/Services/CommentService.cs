using InstagramClone.Bll.DTOs;
using InstagramClone.Dal.Entities;
using InstagramClone.Repository.Services;

namespace InstagramClone.Bll.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<long> AddComment(CommentDto comment)
    {
        return await _commentRepository.AddComment(ConvertToCommentEntity(comment));
    }

    public async Task DeleteComment(long id)
    {
        await _commentRepository.DeleteComment(id);
    }

    public async Task<List<CommentDto>> GetAllComments()
    {
        var comments = await _commentRepository.GetAllComments();
        return comments.Select(c => ConvertToDto(c)).ToList();
    }

    public async Task<CommentDto> GetCommentById(long id)
    {
        return ConvertToDto(await _commentRepository.GetCommentById(id));
    }

    public async Task UpdateComment(CommentDto comment)
    {
        await _commentRepository.UpdateComment(ConvertToCommentEntity(comment));
    }

    private Comment ConvertToCommentEntity(CommentDto commentDto)
    {
        return new Comment
        {
            ContentText = commentDto.ContentText,
            AccountId = commentDto.AccountId,
            PostId = commentDto.PostId,
            WritingTime = commentDto.WritingTime,
            ReplyToCommentId = commentDto.ReplyToCommentId,
        };
    }

    private CommentDto ConvertToDto(Comment comment)
    {
        return new CommentDto
        {
            ContentText = comment.ContentText,
            PostId= comment.PostId,
            AccountId= comment.AccountId,
            CommentId = comment.CommentId,
            WritingTime = comment.WritingTime,
            ReplyToCommentId = comment.ReplyToCommentId,
        };
    }
}
