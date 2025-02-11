using FluentValidation;
using Instagram.Bll.Dtos;
using Instagram.Repository.Services;

namespace Instagram.Bll.Validators;

public class PostCreateDtoValidator : AbstractValidator<PostCreateDto>
{
    private readonly IPostRepository _postRepository;

    public PostCreateDtoValidator(IPostRepository postRepository)
    {
        _postRepository = postRepository;
        RuleFor(post => post.PostType)
            .NotEmpty()
            .WithMessage("Title is required.");
        RuleFor(post => post.AccountId)
            .NotEmpty()
            .WithMessage("Content is required.");
    }

    private async Task<bool> PostExists(long? id, CancellationToken token)
    {
        if (id == null) return true;
        return await _postRepository.PostExistsAsync(id.Value);
    }
}
