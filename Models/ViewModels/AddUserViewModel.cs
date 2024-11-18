using System.ComponentModel.DataAnnotations;

namespace WebProgrammingAflevering.Models.ViewModels
{
    public class AddUserViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string RepeatPassword { get; set; }

    }
}
