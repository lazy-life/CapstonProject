using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DataAccess.DAO
{
    public class CartDAO
    {
        public List<Cart> GetCartByUserID(int id)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                return context.Carts.Where(x => x.UserId == id && x.Status == 0).ToList();
            }
        }
        public void AddCartByUserID(int usId, int productId, int detailProductId, int amount)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                var cartExist = context.Carts.FirstOrDefault(x => x.UserId == usId && x.ProductId == productId && x.ProductDetailId == detailProductId);
                if (cartExist != null)
                {
                    cartExist.Amount = amount;
                    context.SaveChanges();
                }
                else
                {
                    Cart cart = new Cart();
                    cart.UserId = usId;
                    cart.ProductId = productId;
                    cart.ProductDetailId = detailProductId;
                    cart.Amount = amount;
                    context.Carts.Add(cart);
                    context.SaveChanges();
                }
            }
        }
        public void DeleteCartById(int id)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                var cart = context.Carts.FirstOrDefault(x => x.CartId == id);
                if (cart != null)
                    context.Carts.Remove(cart);
                context.SaveChanges();
            }
        }
        public void UpdateCartById(int id, int amount)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                Cart cart = context.Carts.FirstOrDefault(x => x.CartId == id);
                context.SaveChanges();
            }
        }
    }
}
