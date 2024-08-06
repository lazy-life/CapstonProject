using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    [Table("ProductDetail")]
    public class ProductDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductDetailId { get; set; }
        [Required]
        public string ProductDetailName { get; set; }
        public double ProductDetailPrice { get; set; }
        public int DetailPriceDiscount { get; set; }
        public int DetailStock { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
