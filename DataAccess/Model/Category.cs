using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public int Status { get; set; }
    }
}
