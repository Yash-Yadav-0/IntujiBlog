using IntujiBlog.DTOs;
using IntujiBlog.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace IntujiBlog.Data.Repository.IRepository
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Blogs>> GetBlogsAsync();
        Task<Blogs> GetBlogsAsync(Guid id);
        Task<Blogs> AddBlogsAsync(Blogs blogs);
        Task<Blogs> UpdateBlogsAsync(Blogs blogs);
        Task DeleteBlogsAsync(Guid id);
        Task<Blogs>PatchBlogsAsync(Guid Id,JsonPatchDocument<BlogsCreationDto> patchBlogs);
    }
}
