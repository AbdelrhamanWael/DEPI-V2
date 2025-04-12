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

        [Required] 
        [MaxLength(255)] 
        public string FirstName { get; set; }

        [Required] 
        [MaxLength(255)] 
        public string LastName { get; set; }

        [Required] 
        [MaxLength(255)] 
        [EmailAddress]
        public virtual string Email { get; set; } 

        [MaxLength(20)] 
        public string PhoneNumber { get; set; }

        [Column(TypeName = "TEXT")] 
        public string Address { get; set; }

        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow; 
    }
}
