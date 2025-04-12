using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DEPI_V2.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        [ForeignKey("User")] 
        public string UserId { get; set; }

        public DateTime? OrderDate { get; set; } 

        [MaxLength(255)] 
        public string? OrderStatus { get; set; }

        [Required]  
        [Column(TypeName = "TEXT")]
        public string ShippingAddress { get; set; } = null!;

        [Required] 
        [Column(TypeName = "TEXT")]
        public string BillingAddress { get; set; } = null!;

        [Required] 
        public decimal TotalAmount { get; set; }

        [MaxLength(255)] 
        public string? PaymentMethod { get; set; }

        [MaxLength(255)] 
        public string? TransactionId { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual User User { get; set; } 

    }
}
