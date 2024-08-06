using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessLogic.DTO
{
    public class ProductDetailDTO
    {
        public int ProductDetailId { get; set; }
        public string ProductDetailName { get; set; }
        public double ProductDetailPrice { get; set; }
        public int DetailPriceDiscount { get; set; }
        public int DetailStock { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProductId { get; set; }
    }
}
