using System.ComponentModel.DataAnnotations;

namespace DEPI_V2.ViewModels
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [MaxLength(255, ErrorMessage = "Email cannot exceed 255 characters")]
        [Display(Name = "Email")]
        public required string Email { get; set; }
    }
}
