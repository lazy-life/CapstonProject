using BussinessLogic.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.IService
{
    public interface IProductService
    {
        List<ProductDTO> GetProducts();
        void SaveProduct(ProductDTO productDto);
        void DeleteProduct(int ProductID);
        void UpdateProduct(ProductDTO productDto);
        ProductDTO GetProductById(int ProductID);
    }
}
