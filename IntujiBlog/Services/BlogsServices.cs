using AutoMapper;
using IntujiBlog.Data.DbContext;
using IntujiBlog.Data.Repository.IRepository;
using IntujiBlog.DTOs;
using IntujiBlog.Entities;
using IntujiBlog.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace IntujiBlog.Services
{
    public class BlogsServices : IBlogsServices
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public BlogsServices(IBlogRepository blogRepository, IMapper mapper,ApplicationDbContext context)
        {
            _blogRepository = blogRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException("context");
        }

        public async Task<BlogsDisplayDto> AddBlogsAsync(BlogsCreationDto blogs)
        {
            var blogEntity = _mapper.Map<Blogs>(blogs);
            var addedBlog = await _blogRepository.AddBlogsAsync(blogEntity);
            return _mapper.Map<BlogsDisplayDto>(addedBlog);
        }

        public async Task DeleteBlogs(Guid Id)
        {
            await _blogRepository.DeleteBlogsAsync(Id);
        }

        public async Task<IEnumerable<BlogsDisplayDto>> GetAllBlogsAsync()
        {
            var blogs = await _blogRepository.GetBlogsAsync();
            return _mapper.Map<IEnumerable<BlogsDisplayDto>>(blogs);
        }

        public async Task<BlogsDisplayDto> GetBlogsAsync(Guid Id)
        {
            var blog = await _blogRepository.GetBlogsAsync(Id);
            return _mapper.Map<BlogsDisplayDto>(blog);
        }

        public async Task<BlogsDisplayDto> PatchBlogsDetails(Guid Id, JsonPatchDocument<BlogsCreationDto> patchBlogsDetails)
        {
            var blogEntity = await _blogRepository.GetBlogsAsync(Id);
            if (blogEntity == null)
            {
                // Handle not found
                return null;
            }

            // Map entity to DTO
            var blogDto = _mapper.Map<BlogsCreationDto>(blogEntity);

            // Apply patch operations to DTO
            patchBlogsDetails.ApplyTo(blogDto);

            // Map DTO back to entity
            _mapper.Map(blogDto, blogEntity);

            // Save changes
            var updatedBlog = await _blogRepository.UpdateBlogsAsync(blogEntity);
            return _mapper.Map<BlogsDisplayDto>(updatedBlog);
        }




        public async Task<BlogsDisplayDto> UpdateBlogsAsync(Guid Id, BlogsUpdateDto blogs)
        {
            var blogEntity = await _blogRepository.GetBlogsAsync(Id);
            if (blogEntity == null)
            {
                // Handle not found
                return null;
            }

            _mapper.Map(blogs, blogEntity);

            var updatedBlog = await _blogRepository.UpdateBlogsAsync(blogEntity);
            return _mapper.Map<BlogsDisplayDto>(updatedBlog);
        }
    }
}
