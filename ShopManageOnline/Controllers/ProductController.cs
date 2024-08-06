using AutoMapper;
using BussinessLogic.DTO;
using BussinessLogic.IService;
using BussinessLogic.Service;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;

namespace ShopManageOnline.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetProducts")]
        public ActionResult<ProductDTO> Get()
        {
            try
            {
                List<ProductDTO> listProducts = _productService.GetProducts();
                if (listProducts == null)
                {
                    return NotFound();
                }
                return Ok(listProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddProduct")]
        public ActionResult<ProductDTO> Post(ProductRequest request)
        {
            int id = _productService.SaveProduct(request.Product, request.ProductDetails);
            return Ok(id);
        }

        [HttpGet("{ProductId}")]
        public ActionResult<ProductRequest> GetProductById(int ProductId)
        {
            return _productService.GetProductByIdDetail(ProductId);
        }

        [HttpGet("search/{key}")]
        public ActionResult<ProductDTO> Search(string key)
        {
            try
            {
                List<ProductDTO> listProducts = _productService.SearchProducts(key);
                if (listProducts == null)
                {
                    return NotFound();
                }
                return Ok(listProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
