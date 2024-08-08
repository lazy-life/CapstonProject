using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }
        public int UserId { get; set; }
        public double TotalMoney { get; set; }
        public string AddressDetail { get; set; }
        public int AddressId { get; set; }
    }
}
