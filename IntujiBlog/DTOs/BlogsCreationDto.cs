using System.ComponentModel.DataAnnotations;

namespace IntujiBlog.DTOs
{
    public class BlogsCreationDto
    {
        [Required]
        public string BlogTitle { get; set; }

        [Required]
        public string BlogDescription { get; set; }

        public BlogsCreationDto(string blogTitle, string blogDescription)
        {
            BlogTitle = blogTitle;
            BlogDescription = blogDescription;
        }

        public BlogsCreationDto() { }
    }
}
