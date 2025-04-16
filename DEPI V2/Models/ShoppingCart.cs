using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DEPI_V2.Models
{
    public class ShoppingCart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }

        [Required(ErrorMessage = "User is required")]
        [ForeignKey("User")]
        public required string UserId { get; set; }

        public DateTime? DateCreated { get; set; }

        // Navigation properties
        public virtual User? User { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
    }
}
