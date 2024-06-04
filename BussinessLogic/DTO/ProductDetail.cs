using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessLogic.DTO
{
    public class ProductDetailDTO
    {
        public int ProductDetailId { get; set; }
        public string ProductDetailName { get; set; }
        public double ProductDetailPrice { get; set; }
        public DateTime ProductDetailData { get; set; }
        public int ProductId { get; set; }
    }
}
