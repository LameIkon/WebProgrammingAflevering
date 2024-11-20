using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebProgrammingAflevering.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Username), IsUnique = true)]
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [RegularExpression(@"[a-z0-9]+@[a-z0-9]+\.{1}[a-z]+\.?[a-z]+")]
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 8)]
        [RegularExpression(@"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,30}")]
        public string Password { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Username { get; set; }

        public ICollection<Post>? Posts { get; set; }

    }
}
