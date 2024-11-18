using System.ComponentModel.DataAnnotations;

namespace WebProgrammingAflevering.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(100, ErrorMessage = "Max 100 characters allowed.")]
        //TODO: Insert the RegEx for confirming emails
        //[RegularExpression(@"^", ErrorMessage = "Please Enter a valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Max 30 and min 8 characters allowed.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
