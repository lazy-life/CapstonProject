using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class ProductDAO
    {
        public IEnumerable<Product> GetProducts()
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                return context.Products.ToList();
            }
        }

        public void DeleteProduct(int id)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                Product product = context.Products.FirstOrDefault(x => x.ProductId == id);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
            }
        }

        public void SaveProduct(Product product)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                product.CreateAt = DateTime.Now;
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void UpdateProduct(Product product)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                Product productExist = context.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
                if (productExist != null)
                {
                    productExist.ProductName = product.ProductName;
                    productExist.ProductPrice = product.ProductPrice;
                    productExist.ProductSalePrice = product.ProductSalePrice;
                    productExist.ProductCost = product.ProductCost;
                    productExist.CategoryId = product.CategoryId;
                    productExist.UserId = product.UserId;
                    productExist.UpdateAt = DateTime.Now;

                    context.SaveChanges();
                }
            }
        }

        public Product GetProductById(int productID)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                Product productExist = context.Products.FirstOrDefault(x => x.ProductId == productID);
                if (productExist != null)
                {
                    return productExist;
                }
                return null;
            }
        }
    }
}
