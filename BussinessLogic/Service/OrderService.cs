using AutoMapper;
using BussinessLogic.DTO;
using DataAccess.DAO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Service
{
    public class OrderService
    {
        private readonly IMapper _mapper;
        public OrderService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public void SaveOrder(List<OrderDTO> request)
        {
            var data = _mapper.Map<List<Order>>(request);
            using (DataAccessContext context = new DataAccessContext())
            {
                foreach (var d in data)
                {
                    Order o = new Order();
                    o.OrderDate = DateTime.Now;
                    o.UserId = d.UserId;
                    o.TotalMoney = d.TotalMoney;
                    o.ProductDetailName = d.ProductDetailName;
                    o.ProductName = d.ProductName;
                    o.ProductId = d.ProductId;
                    o.AddressId = d.AddressId;
                    context.Orders.Add(o);
                    context.SaveChanges();
                }
            }
        }
    }
}
