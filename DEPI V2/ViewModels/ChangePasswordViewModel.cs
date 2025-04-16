using System.ComponentModel.DataAnnotations;

namespace DEPI_V2.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [MaxLength(255, ErrorMessage = "Email cannot exceed 255 characters")]
        [Display(Name = "Email")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "New password is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public required string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm new password is required")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        [Display(Name = "Confirm New Password")]
        public required string ConfirmNewPassword { get; set; }
    }
}
