using IntujiBlog.DTOs;
using IntujiBlog.Entities;
using IntujiBlog.Services.IServices;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntujiBlog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogsServices _blogsServices;

        public BlogsController(IBlogsServices blogsServices)
        {
            _blogsServices = blogsServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogsDisplayDto>>> GetAllBlogs()
        {
            var blogs = await _blogsServices.GetAllBlogsAsync();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogsDisplayDto>> GetBlog(Guid id)
        {
            var blog = await _blogsServices.GetBlogsAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public async Task<ActionResult<BlogsDisplayDto>> AddBlog(BlogsCreationDto blogDto)
        {
            var addedBlog = await _blogsServices.AddBlogsAsync(blogDto);
            return Ok(addedBlog);
            //return CreatedAtAction(nameof(GetBlog), new { id = addedBlog.Id }, addedBlog);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<BlogsDisplayDto>> PatchBlog(Guid id, [FromBody] JsonPatchDocument<BlogsCreationDto> patchDocument)
        {
            var patchedBlog = await _blogsServices.PatchBlogsDetails(id, patchDocument);
            if (patchedBlog == null)
            {
                return NotFound();
            }
            return Ok(patchedBlog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(Guid id, BlogsUpdateDto blogDto)
        {
            var updatedBlog = await _blogsServices.UpdateBlogsAsync(id, blogDto);
            if (updatedBlog == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteBlog(Guid id)
        {
            _blogsServices.DeleteBlogs(id);
            return NoContent();
        }
    }
}
