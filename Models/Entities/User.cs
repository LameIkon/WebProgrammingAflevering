using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebProgrammingAflevering.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(100, ErrorMessage = "Max 100 characters allowed.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(30, ErrorMessage = "Max 30 characters allowed.")]
        public string Password { get; set; }


        public ICollection<Post>? Posts { get; set; }

    }
}
