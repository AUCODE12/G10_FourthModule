﻿using AutoMapper;
using Instagram.Bll.Dtos;
using Instagram.Dal.Entities;

namespace Instagram.Bll.MappingProfiles;

public class PostProfile : Profile
{
    public PostProfile()
    {
        CreateMap<PostCreateDto, Post>();
        CreateMap<Post, PostGetDto>();
    }
}
