using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DEPI_V2.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [MaxLength(255)]
        public required string Name { get; set; }

        [Column(TypeName = "TEXT")]
        public string? Description { get; set; }

        // Navigation properties
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
