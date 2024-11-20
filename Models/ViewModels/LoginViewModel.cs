using System.ComponentModel.DataAnnotations;

namespace WebProgrammingAflevering.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(100)]
        [RegularExpression(@"[a-z0-9]+@[a-z0-9]+\.{1}[a-z]+\.?[a-z]+")]
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 8)]
        [RegularExpression(@"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,30}")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
