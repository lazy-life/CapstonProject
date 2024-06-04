using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessLogic.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public double ProductSalePrice { get; set; }
        public double ProductCost { get; set; }
        public DateTime ProductDate { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
        public DateTime CreateAt { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
    }
}
