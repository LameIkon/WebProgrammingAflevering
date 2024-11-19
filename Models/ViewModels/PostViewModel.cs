using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProgrammingAflevering.Models.ViewModels
{
    public class PostViewModel
    {
        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        [ForeignKey("User")]
        public Guid UserRefId { get; set; }


    }
}
