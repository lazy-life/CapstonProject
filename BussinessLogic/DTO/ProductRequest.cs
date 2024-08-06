using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DTO
{
    public class ProductRequest
    {
        public ProductDTO Product { get; set; }
        public List<ProductDetailDTO> ProductDetails { get; set; }
    }
}
