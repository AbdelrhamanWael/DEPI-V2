using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DEPI_V2.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "User is required")]
        [ForeignKey("User")]
        public required string UserId { get; set; }

        public DateTime? OrderDate { get; set; }

        [MaxLength(255)]
        public string? OrderStatus { get; set; }

        [Required(ErrorMessage = "Shipping address is required")]
        [Column(TypeName = "TEXT")]
        public required string ShippingAddress { get; set; }

        [Required(ErrorMessage = "Billing address is required")]
        [Column(TypeName = "TEXT")]
        public required string BillingAddress { get; set; }

        [Required(ErrorMessage = "Total amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Total amount must be greater than 0")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [MaxLength(255)]
        public string? PaymentMethod { get; set; }

        [MaxLength(255)]
        public string? TransactionId { get; set; }

        // Navigation properties
        public virtual User? User { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}