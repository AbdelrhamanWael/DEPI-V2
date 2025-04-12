using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DEPI_V2.Models
{
    public class ShoppingCart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }

        [Required]
        [ForeignKey("User")] 
        public string UserId { get; set; }

        public DateTime? DateCreated { get; set; } 

        public virtual User User { get; set; }
    }
}
