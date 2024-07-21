using AutoMapper;
using BussinessLogic.DTO;
using BussinessLogic.IService;
using BussinessLogic.Service;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace ShopManageOnline.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CartController(IMapper mapper, ICartService cartService, IProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("{UsId}")]
        public ActionResult<CartDTO> GetCartById(int UsId)
        {
            var cartData = _cartService.GetCartByUserID(UsId);
            List<CartDataDetail> data = new List<CartDataDetail>();
            foreach (var cart in cartData)
            {
                ProductDTO product =  _productService.GetProductById(cart.ProductId);
                CartDataDetail cardData = new CartDataDetail();
                cardData.ProductId = cart.ProductId;
                cardData.UserId = cart.UserId;
                cardData.CartId = cart.CartId;
                cardData.ProductName = product.ProductName;
                cardData.ProductPrice = product.ProductPrice;
                cardData.ProductSalePrice = product.ProductSalePrice;
                cardData.Amount = cart.Amount;
                data.Add(cardData);
            }
            return data == null
                ? BadRequest()
                : Ok(data);
        }

        [HttpPost("AddCart")]
        public ActionResult<CartDTO> Post([FromBody] JsonObject data)
        {
            //int id, int productId, int detailProductId, int amount
            int id = data["id"].GetValue<int>();
            int productId = data["productId"].GetValue<int>();
            int detailProductId = data["detailProductId"].GetValue<int>();
            int amount = data["amount"].GetValue<int>();
            _cartService.AddCartByUserID(id, productId, detailProductId, amount);
            return Ok(id);
        }

        [HttpPut("UpdateCart")]
        public ActionResult<CartDTO> Put(int id, int amount)
        {
            _cartService.UpdateCartById(id, amount);
            return Ok(id);
        }

        [HttpDelete("DeleteCart")]
        public ActionResult<CartDTO> Delete(int id)
        {
            _cartService.DeleteCartById(id);
            return Ok(id);
        }

    }
}
