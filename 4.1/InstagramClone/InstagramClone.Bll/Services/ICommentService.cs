using InstagramClone.Bll.DTOs;

namespace InstagramClone.Bll.Services;

public interface ICommentService
{
    Task<long> AddComment(CommentCreateDto comment);

    Task DeleteComment(long id);

    Task UpdateComment(CommentCreateDto comment);

    Task<CommentDto> GetCommentById(long id);

    Task<List<CommentDto>> GetAllComments();
}