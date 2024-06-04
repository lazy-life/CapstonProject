using AutoMapper;
using BussinessLogic.DTO;
using BussinessLogic.IService;
using DataAccess.DAO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Service
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly ProductDAO _productDAO;
        public ProductService(IMapper mapper, ProductDAO productDAO)
        {
            _mapper = mapper;
            _productDAO = productDAO;
        }

        public void DeleteProduct(int ProductID)
        {
            _productDAO.DeleteProduct(ProductID);
        }

        public ProductDTO GetProductById(int ProductID)
        {
            return _mapper.Map<ProductDTO>(_productDAO.GetProductById(ProductID));
        }

        public List<ProductDTO> GetProducts()
        {
            return _mapper.Map<List<ProductDTO>>(_productDAO.GetProducts());
        }

        public void UpdateProduct(ProductDTO productDto)
        {
            _productDAO.UpdateProduct(_mapper.Map<Product>(productDto));
        }

        public void SaveProduct(ProductDTO productDto)
        {
            _productDAO.SaveProduct(_mapper.Map<Product>(productDto));
        }
    }
}
