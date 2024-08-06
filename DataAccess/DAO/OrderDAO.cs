using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class OrderDAO
    {
        public IEnumerable<Order> GetOrderByUsId(int usId)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                return context.Orders.Where(x => x.UserId == usId).ToList();
            }
        }

        //public void AddOrder(int usId, List<int> cartIdList)
        //{
        //    using (DataAccessContext context = new DataAccessContext())
        //    {
        //        foreach (var c in cartIdList)
        //        {

        //        }
        //        var cartAdd = context.Carts.FirstOrDefault(x => x.CartId == cartId);
        //        if(cartAdd != null)
        //        {
        //            Order order = new Order();
        //            order.UserId = usId;
        //            order.CartId = cartId;
        //            order.OrderDate = DateTime.Now;
        //            order.OrderStatus = 0;
        //            order.TotalMoney = cartAdd.
        //        }
        //        context.Categories.Add(category);
        //        context.SaveChanges();
        //    }
        //}
    }
}
