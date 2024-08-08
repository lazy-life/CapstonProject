using AutoMapper;
using BussinessLogic.DTO;
using BussinessLogic.IService;
using BussinessLogic.Service;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;

namespace ShopManageOnline.Controllers
{
    public class OrderControllers : Controller
    {
        private readonly OrderService _orderService;
        private readonly IMapper _mapper;

        public OrderControllers(IMapper mapper, OrderService orderService)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        [HttpPost("AddOrder")]
        public ActionResult<OrderDTO> Post([FromBody] AddOrderRequestDto request)
        {
            try
            {
                _orderService.SaveOrder(request.Items);
                return Ok("OK");
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("GetOrderID/{id}")]
        public ActionResult<OrderRequest> Get(int id)
        {
            try
            {
                var data = _orderService.GetOrderUsId(id);
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetAllOrder")]
        public ActionResult<List<Order>> GetOrder()
        {
            try
            {
                var data = _orderService.GetAllOrder();
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
