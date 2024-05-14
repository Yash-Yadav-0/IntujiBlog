using IntujiBlog.DTOs;
using IntujiBlog.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntujiBlog.Services.IServices
{
    public interface IBlogsServices
    {
        Task<BlogsDisplayDto> GetBlogsAsync(Guid Id);
        Task<IEnumerable<BlogsDisplayDto>> GetAllBlogsAsync();
        Task<BlogsDisplayDto> AddBlogsAsync(BlogsCreationDto blogs);
        Task DeleteBlogs(Guid Id);
        Task<BlogsDisplayDto> UpdateBlogsAsync(Guid Id, BlogsUpdateDto blogs);
        Task<BlogsDisplayDto> PatchBlogsDetails(Guid Id, JsonPatchDocument<BlogsCreationDto> patchBlogsDetails);
    }
}
