using AutoMapper;
using IntujiBlog.DTOs;
using IntujiBlog.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Blogs, BlogsDisplayDto>();
        CreateMap<BlogsDisplayDto, Blogs>();
        
        CreateMap<Blogs,BlogsCreationDto>();
        CreateMap<BlogsCreationDto, Blogs>();

        CreateMap<BlogsUpdateDto, Blogs>();
        CreateMap<Blogs,BlogsUpdateDto>();
    }
}
