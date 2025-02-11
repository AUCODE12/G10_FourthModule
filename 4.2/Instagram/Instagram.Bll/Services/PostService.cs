using AutoMapper;
using FluentValidation;
using Instagram.Bll.Dtos;
using Instagram.Dal.Entities;
using Instagram.Repository.Services;

namespace Instagram.Bll.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IValidator<PostCreateDto> _commentCreateDtoValidator;
    private readonly IMapper Mapper;
    
    
    public PostService(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        Mapper = mapper;
    }

    public async Task<long> AddPost(PostCreateDto post)
    {
        var validatorRes = await _commentCreateDtoValidator.ValidateAsync(post);
        if (!validatorRes.IsValid)
        { 
            throw new ValidationException($"{string.Join(',', validatorRes.Errors)}");
        }

        var postMapConvert = Mapper.Map<Post>(post);
        postMapConvert.CreatedTime = DateTime.UtcNow;
        return await _postRepository.AddPost(postMapConvert);
    }

    public async Task<List<PostGetDto>> GetAllPosts()
    {
        var posts = await _postRepository.GetAllPosts();
        return posts.Select(p => Mapper.Map<PostGetDto>(p)).ToList();
    }

    public async Task<PostGetDto> GetPostById(long id)
    {
        return Mapper.Map<PostGetDto>(await _postRepository.GetPostById(id));
    }
}
