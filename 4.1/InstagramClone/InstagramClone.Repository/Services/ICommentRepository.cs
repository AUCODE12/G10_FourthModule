using InstagramClone.Dal.Entities;

namespace InstagramClone.Repository.Services;

public interface ICommentRepository
{
    Task<long> AddComment(Comment comment);

    Task DeleteComment(long id);

    Task UpdateComment(Comment comment);

    Task<Comment> GetCommentById(long id);

    Task<List<Comment>> GetAllComments();
}