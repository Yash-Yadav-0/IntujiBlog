using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IntujiBlog.Entities
{
    public class Blogs 
    {
        [Required]
        [MaxLength(50)]
        public Guid Id { get; set; }
        public string BlogTitle { get; set;}
        public string BlogDescription { get; set;}
        public DateTime? CreatedAt { get; set;}=DateTime.UtcNow;
        public DateTime? LastUpdatedAt { get; set;} =DateTime.UtcNow;
        public Blogs()
        {

        }
    }
}
