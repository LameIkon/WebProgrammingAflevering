using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProgrammingAflevering.Models.ViewModels
{
    public class AddPostViewModel
    {
        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public IFormFile Picture { get; set; }

        [Required]
        public Guid UserRefId { get; set; }

    }
}
