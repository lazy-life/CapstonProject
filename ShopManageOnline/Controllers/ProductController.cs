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

        [HttpGet("GetProductsSale")]
        public ActionResult<ProductDTO> GetProductSale()
        {
            try
            {
                List<ProductDTO> listProducts = _productService.GetProductsSale();
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
        [HttpGet("GetProductsNotSale")]
        public ActionResult<ProductDTO> GetProductNotSale()
        {
            try
            {
                List<ProductDTO> listProducts = _productService.GetProductsNotSale();
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
        [HttpGet("GetProductsAll")]
        public ActionResult<ProductDTO> GetProductAll()
        {
            try
            {
                List<ProductDTO> listProducts = _productService.GetProductsAll();
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

        [HttpGet("GetProductByCateId/{id}")]
        public ActionResult<ProductDTO> GetProductByCateId(int id)
        {
            try
            {
                List<ProductDTO> listProducts = _productService.GetProductsById(id);
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

        [HttpPut]
        public ActionResult Put(ProductRequest request)
        {
            try
            {
                _productService.EditProduct(request.Product, request.ProductDetails);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{ProductId}")]
        public ActionResult<ProductRequest> GetProductById(int ProductId)
        {
            return _productService.GetProductByIdDetail(ProductId);
        }

        [HttpDelete("removeProduct/{id}")]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("removeDetailProduct/{id}")]
        public ActionResult DeleteDetailProduct(int id)
        {
            try
            {
                _productService.DeleteDetailProduct(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
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
        [HttpPost("UpdateSale/{id}/{percent}")]
        public ActionResult<ProductDTO> UpdateSale(int id, double percent)
        {
            try
            {
                _productService.UpdateSaleProduct(id, percent);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("RemoveSale/{id}")]
        public ActionResult<ProductDTO> RemoveSale(int id)
        {
            try
            {
                _productService.RemoveSaleProduct(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
