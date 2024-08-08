using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }
        public double TotalMoney { get; set; }
        public string ProductDetailName { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int ProductDetailId { get; set; }
        public int Amount { get; set; }
        public int OrderId { get; set; }
        public string ImgUrl { get; set; }
    }
}
