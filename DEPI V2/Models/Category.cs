using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DEPI_V2.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = null!;

        [Column(TypeName = "TEXT")]
        public string? Description { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
