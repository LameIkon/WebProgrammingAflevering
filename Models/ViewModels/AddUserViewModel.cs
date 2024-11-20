using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebProgrammingAflevering.Models.ViewModels
{
    public class AddUserViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [RegularExpression(@"[a-z0-9]+@[a-z0-9]+\.{1}[a-z]+\.?[a-z]+")]
        public string Email { get; set; }


        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Username { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 8)]
        [RegularExpression(@"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,30}")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        [DisplayName("Repeat Password")]
        public string RepeatPassword { get; set; }

    }
}
