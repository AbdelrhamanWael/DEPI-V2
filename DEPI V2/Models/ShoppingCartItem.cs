using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DEPI_V2.Models
{
    public class ShoppingCartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartItemId { get; set; }

        [Required(ErrorMessage = "Shopping cart is required")]
        [ForeignKey("ShoppingCart")]
        public required int CartId { get; set; }

        [Required(ErrorMessage = "Product is required")]
        [ForeignKey("Product")]
        public required int ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Unit price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Unit price must be greater than 0")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        // Navigation properties
        public virtual ShoppingCart? ShoppingCart { get; set; }
        public virtual Product? Product { get; set; }
    }
}
