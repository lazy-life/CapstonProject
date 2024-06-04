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
        public ActionResult<ProductDTO> Post(ProductDTO p)
        {
            _productService.SaveProduct(p);
            return NoContent();
        }

        [HttpGet("AddCategory/{ProductId}")]
        public ActionResult<ProductDTO> GetProductById(int ProductId)
        {
            return _productService.GetProductById(ProductId);
        }


    }
}
