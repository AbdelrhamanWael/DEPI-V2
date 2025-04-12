using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DEPI_V2.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; } = null!;

        [Column(TypeName = "TEXT")]
        public string? Description { get; set; }

       

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        [MaxLength(255)] // Assuming a reasonable max length for Brand
        public string? Brand { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MaxLength(255)] // Assuming a reasonable max length for ImageUrl
        public string? ImageUrl { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        public virtual Category? Category { get; set; } // Navigation property
    }
}
