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
            var data = _mapper.Map<List<OrderResultDTO>>(request);
            using (DataAccessContext context = new DataAccessContext())
            {
                var dateTime = DateTime.Now;
                double totalMon = 0;
                foreach (var d in data)
                {
                    totalMon += d.TotalMoney;
                }
                Order o = new Order();
                o.OrderDate = dateTime;
                o.UserId = data[0].UserId;
                o.TotalMoney = totalMon;
                o.OrderStatus = 1;
                o.AddressDetail = GetAddressByID(data[0].AddressId);
                context.Orders.Add(o);
                context.SaveChanges();

                foreach (var d in data)
                {
                    OrderDetail od = new OrderDetail();
                    od.ProductDetailName = d.ProductDetailName;
                    od.ProductName = d.ProductName;
                    od.ProductId = d.ProductId;
                    od.Amount = d.Amount;
                    od.OrderId = o.OrderId;
                    od.TotalMoney = o.TotalMoney;
                    od.ImgUrl = context.Products.FirstOrDefault(x => x.ProductId == d.ProductId).Img1;
                    context.OrderDetails.Add(od);
                    context.SaveChanges();
                    context.Carts.Remove(context.Carts.FirstOrDefault(x => x.CartId == d.CartId));
                    context.SaveChanges();
                    context.ProductDetails.FirstOrDefault(x => x.ProductDetailName.Equals(d.ProductDetailName)).DetailStock -= d.Amount;
                    context.SaveChanges();
                }


            }
        }

        public List<OrderRequest> GetOrderUsId(int usId)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                var orderLst = context.Orders.Where(x => x.UserId == usId).ToList();
                var lstRequest = new List<OrderRequest>();
                if(orderLst.Count > 0)
                {
                    foreach (var lst in orderLst)
                    {
                        OrderRequest or = new OrderRequest();
                        or.Orders = lst;
                        or.OrderDetails = context.OrderDetails.Where(x => x.OrderId == lst.OrderId).ToList();
                        lstRequest.Add(or);
                    }
                    return lstRequest;
                }
                return null;
            }
        }

        public string GetAddressByID(int id)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                var data = context.Addresses.FirstOrDefault(x => x.AddressID == id);
                var city = context.Cities.FirstOrDefault(x => x.Matp == data.Matp).Name;
                var district = context.Districts.FirstOrDefault(x => x.Maqh == data.Maqh).Name;
                var ward = context.Wards.FirstOrDefault(x => x.Xaid == data.Mapx).Name;
                return $"{data.Detail} {ward} {district} {city}";
            }
        }

        public List<Order> GetAllOrder()
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                return context.Orders.ToList();
            }
        }
    }
}
