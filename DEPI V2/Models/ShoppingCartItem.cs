using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DEPI_V2.Models

{
    public class ShoppingCartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartItemId { get; set; }

        [Required]
        [ForeignKey("Cart")] // Assuming you have a Cart class
        public int CartId { get; set; }

        [Required]
        [ForeignKey("Product")] // Assuming you have a Product class
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        public virtual ShoppingCart ShoppingCarts { get; set; } 
        public virtual Product Product { get; set; } 

    }
}
