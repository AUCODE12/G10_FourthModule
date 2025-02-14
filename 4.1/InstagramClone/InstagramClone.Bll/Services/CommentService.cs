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

    public async Task<long> AddComment(CommentCreateDto comment)
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

    public async Task UpdateComment(CommentCreateDto comment)
    {
        await _commentRepository.UpdateComment(ConvertToCommentEntity(comment));
    }

    private Comment ConvertToCommentEntity(CommentCreateDto commentDto)
    {
        return new Comment
        {
            ContentText = commentDto.ContentText,
            AccountId = commentDto.AccountId,
            PostId = commentDto.PostId,
            ReplyToCommentId = commentDto.ReplyToCommentId,
            WritingTime = DateTime.UtcNow
        };
    }

    private CommentDto ConvertToDto(Comment comment)
    {
        return new CommentDto
        {
            ContentText = comment.ContentText,
            PostId= comment.PostId,
            AccountId= comment.AccountId,
            WritingTime = comment.WritingTime,
            ReplyToCommentId = comment.ReplyToCommentId,
            Account = comment.Account != null ? new AccountDto
            {
                AccountId = comment.Account.AccountId,
                Bio = comment.Account.Bio,
                Username = comment.Account.Username,
            } : null,
            Post = comment.Post != null ? new PostDto
            {
                AccountId = comment.Post.AccountId,
                SetTime = comment.Post.SetTime,
                PostId = comment.Post.PostId,
                PostType = comment.Post.PostType,
            } : null,
            Replies = comment.Replies?.Select(r => new CommentDto
            {
                AccountId = r.AccountId,
                ContentText = r.ContentText,
                PostId = r.PostId,
                WritingTime = r.WritingTime,
            }).ToList(),
            ReplyToComment = comment.ReplyToComment != null ? new CommentDto
            {
                AccountId = comment.ReplyToComment.AccountId,
                ContentText = comment.ReplyToComment.ContentText,
                PostId = comment.ReplyToComment.PostId,
                WritingTime = comment.ReplyToComment.WritingTime,
            } : null,
        };
    }
}
