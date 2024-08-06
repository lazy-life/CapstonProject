using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DTO
{
    public class CartDataDetail
    {
        public int CartId { get; set; }
        public DateTime CartDate { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public int ProductDetailId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public double ProductSalePrice { get; set; }
        public double ProductCost { get; set; }
        public int ProductStock { get; set; }
        public string ProductDescription { get; set; }
        public DateTime ProductDate { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
        public DateTime CreateAt { get; set; }
        public int CategoryId { get; set; }
        public string ImgUrl { get; set; }
        public string ProductDetailName { get; set; }
        public double ProductDetailPrice { get; set; }
        public DateTime ProductDetailData { get; set; }
    }
}
