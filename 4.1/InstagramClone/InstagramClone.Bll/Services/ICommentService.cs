using InstagramClone.Bll.DTOs;

namespace InstagramClone.Bll.Services;

public interface ICommentService
{
    Task<long> AddComment(CommentDto comment);

    Task DeleteComment(long id);

    Task UpdateComment(CommentDto comment);

    Task<CommentDto> GetCommentById(long id);

    Task<List<CommentDto>> GetAllComments();
}