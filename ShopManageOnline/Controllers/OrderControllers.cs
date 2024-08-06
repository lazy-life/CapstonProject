using AutoMapper;
using BussinessLogic.DTO;
using BussinessLogic.IService;
using BussinessLogic.Service;
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
            _orderService.SaveOrder(request.Items);
            return Ok();
        }
    }
}
