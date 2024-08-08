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
        List<ProductDTO> SearchProducts(string key);
        int SaveProduct(ProductDTO productDto, List<ProductDetailDTO> productDetailDTOs);
        void DeleteProduct(int ProductID);
        void UpdateProduct(ProductDTO productDto);
        ProductDTO GetProductById(int ProductID);
        ProductRequest GetProductByIdDetail(int ProductID);
        ProductDetailDTO GetProductDetailById(int productId);
        void DeleteDetailProduct(int id);
        void EditProduct(ProductDTO product, List<ProductDetailDTO> productDetails);
    }
}
