using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DEPI_V2.Models
{
    public class User : IdentityUser
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incrementing
        public int UserID { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [MaxLength(255)] 
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(255)] 
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [MaxLength(255)]
        public override string? Email { get; set; } 

        [MaxLength(20)] 
        public override string? PhoneNumber { get; set; }

        [Column(TypeName = "TEXT")] 
        public string? Address { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow; 

        public bool IsAdmin { get; set; } = false;

        // Navigation properties
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
    }
}