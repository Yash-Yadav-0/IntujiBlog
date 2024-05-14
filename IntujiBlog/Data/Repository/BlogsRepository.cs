using IntujiBlog.Data.DbContext;
using IntujiBlog.Data.Repository.IRepository;
using IntujiBlog.DTOs;
using IntujiBlog.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntujiBlog.Data.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationDbContext _context;

        public BlogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Blogs>> GetBlogsAsync()
        {
            return await _context.SystemBlogs.ToListAsync();
        }

        public async Task<Blogs> GetBlogsAsync(Guid id)
        {
            return await _context.SystemBlogs.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Blogs> AddBlogsAsync(Blogs blogs)
        {
            _context.SystemBlogs.Add(blogs);
            await _context.SaveChangesAsync();
            return blogs;
        }

        public async Task<Blogs> UpdateBlogsAsync(Blogs blogs)
        {
            _context.Entry(blogs).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return blogs;
        }
        public async Task<Blogs> PatchBlogsAsync(Guid id, JsonPatchDocument<BlogsCreationDto> patchBlogs)
        {
            var blogs = await _context.SystemBlogs.FindAsync(id);
            if (blogs == null)
            {
                return null; // Or handle not found appropriately
            }

            var blogToPatch = new BlogsCreationDto(); // Create a new DTO instance
                                                      // Apply patch operations to the DTO
            patchBlogs.ApplyTo(blogToPatch);

            // Update the entity based on the patched DTO
            // You may need to map properties manually here
            // e.g., blogs.BlogTitle = blogToPatch.BlogTitle;

            await _context.SaveChangesAsync();
            return blogs;
        }

        public async Task DeleteBlogsAsync(Guid id)
        {
            var blog = await _context.SystemBlogs.FindAsync(id);
            if (blog != null)
            {
                _context.SystemBlogs.Remove(blog);
                await _context.SaveChangesAsync();
            }
        }

    }
}
