using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessLogic.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public DateTime ProductDate { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
        public DateTime CreateAt { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int Sale { get; set; }
        public int SalePercent { get; set; }
        public double ProductPrice { get; set; }
        public double ProductSalePrice { get; set; }
        public string Img1 { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set; }
        public string Img4 { get; set; }
        public string Img5 { get; set; }
    }
}
