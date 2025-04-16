using System.ComponentModel.DataAnnotations;

namespace DEPI_V2.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(255, ErrorMessage = "First name cannot exceed 255 characters")]
        [Display(Name = "First Name")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(255, ErrorMessage = "Last name cannot exceed 255 characters")]
        [Display(Name = "Last Name")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [MaxLength(255, ErrorMessage = "Email cannot exceed 255 characters")]
        [Display(Name = "Email")]
        public required string Email { get; set; }

        [MaxLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Address")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "Confirm Password")]
        public required string ConfirmPassword { get; set; }
    }
}
