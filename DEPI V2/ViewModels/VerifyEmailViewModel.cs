using System.ComponentModel.DataAnnotations;

namespace DEPI_V2.ViewModels
{
    public class VerifyEmailViewModel
    {

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

    }
}
