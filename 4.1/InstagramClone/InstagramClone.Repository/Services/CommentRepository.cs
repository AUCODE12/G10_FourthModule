using InstagramClone.Dal;
using InstagramClone.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace InstagramClone.Repository.Services;

public class CommentRepository : ICommentRepository
{
    private readonly MainContext _mainContext;

    public CommentRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<long> AddComment(Comment comment)
    {
        await _mainContext.Comments.AddAsync(comment);
        await _mainContext.SaveChangesAsync();
        return comment.CommentId;
    }

    public async Task DeleteComment(long id)
    {
        var commentFind = await GetCommentById(id);
        _mainContext.Comments.Remove(commentFind);
        await _mainContext.SaveChangesAsync();
    }

    public async Task<List<Comment>> GetAllComments()
    {
        return await _mainContext.Comments.ToListAsync();
    }

    public async Task<Comment> GetCommentById(long id)
    {
        var comment = await _mainContext.Comments.FirstOrDefaultAsync(c => c.CommentId == id);
        if (comment is null) throw new Exception("Not Found");
        return comment;
    }

    public async Task UpdateComment(Comment comment)
    {
        var commentFind = await GetCommentById(comment.CommentId);
        commentFind.CommentId = comment.CommentId;
        commentFind.ContentText = comment.ContentText;
        commentFind.WritingTime = comment.WritingTime;
        await _mainContext.SaveChangesAsync();
    }
}
