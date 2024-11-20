using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities.Encoders;
using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProgrammingAflevering.Models.Entities
{
    public class Post
    {
   
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        [RegularExpression(@"/(\.jpg|\.png)/")]
        public string Picture { get; set; }

        [Required]
        [ForeignKey("User")]
        public Guid UserRefId { get; set; }

        public User User { get; set; }
    }
}
