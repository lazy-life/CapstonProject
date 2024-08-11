using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                return context.Products.Where(x => x.Status == 1).ToList();
            }
        }
        public IEnumerable<Product> GetProductsNotSale()
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                return context.Products.Where(x => x.Status == 1 && x.Sale == 0).ToList();
            }
        }

        public IEnumerable<Product> GetProductsSale()
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                return context.Products.Where(x => x.Status == 1 && x.Sale == 1).ToList();
            }
        }
        public IEnumerable<Product> SearchProduct(string key)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                return context.Products.Where(x => x.ProductName.Contains(key) && x.Status == 1).ToList();
            }
        }

        public void DeleteProduct(int id)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                Product product = context.Products.FirstOrDefault(x => x.ProductId == id);
                if (product != null)
                {
                    product.Status = 2;
                    context.SaveChanges();
                }
            }
        }

        public int SaveProduct(Product product, List<ProductDetail> productDetail)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                product.CreateAt = DateTime.Now;
                product.Status = 1;
                product.Sale = 0;
                context.Products.Add(product);
                context.SaveChanges();

                foreach (var p in productDetail)
                {
                    var pd = new ProductDetail();
                    pd.ProductDetailName = p.ProductDetailName;
                    pd.ProductDetailPrice = p.ProductDetailPrice;
                    pd.DetailPriceDiscount = p.DetailPriceDiscount;
                    pd.DetailStock = p.DetailStock;
                    pd.ProductId = product.ProductId;
                    context.ProductDetails.Add(pd);
                    context.SaveChanges();
                }
                return product.ProductId;
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
                Product productExist = context.Products.FirstOrDefault(x => x.ProductId == productID && x.Status == 1);
                if (productExist != null)
                {
                    return productExist;
                }
                return null;
            }
        }

        public void UpdateSaleProduct(int id, double percent)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                Product productExist = context.Products.FirstOrDefault(x => x.ProductId == id && x.Status == 1);
                if (productExist != null)
                {
                    productExist.Sale = 1;
                    productExist.SalePercent = (int)percent;
                    context.SaveChanges();
                }
            }
        }
        public void RemoveSaleProduct(int id)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                Product productExist = context.Products.FirstOrDefault(x => x.ProductId == id && x.Status == 1);
                if (productExist != null)
                {
                    productExist.Sale = 0;
                    productExist.SalePercent = 0;
                    context.SaveChanges();
                }
            }
        }

        public IEnumerable<Product> GetProductByName(string productName)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                var productExist = context.Products.Where(x => x.ProductName.Contains(productName) && x.Status == 1);
                if (productExist != null)
                {
                    return productExist;
                }
                return null;
            }
        }

        public void DeleteDetailProduct(int id)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                var product = context.ProductDetails.FirstOrDefault(x => x.ProductDetailId == id);
                if (product != null)
                {
                    context.ProductDetails.Remove(product);
                    context.SaveChanges();
                }
            }
        }

        public void SaveEditProduct(Product product, List<ProductDetail> productDetails)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                var exist = context.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
                if (exist == null)
                {
                    throw new Exception();
                }

                exist.ProductName = product.ProductName;
                exist.ProductDescription = product.ProductDescription;
                exist.UpdateAt = DateTime.Now;
                exist.Img1 = product.Img1 != "" ? product.Img1 : exist.Img1;
                exist.Img2 = product.Img2 != "" ? product.Img2 : exist.Img2; ;
                exist.Img3 = product.Img3 != "" ? product.Img3 : exist.Img3; ;
                exist.Img4 = product.Img4 != "" ? product.Img4 : exist.Img4; ;
                exist.Img5 = product.Img5 != "" ? product.Img5 : exist.Img5; ;
                context.SaveChanges();

                foreach (var p in productDetails)
                {
                    if (p.ProductDetailId == 0)
                    {
                        var pd = new ProductDetail();
                        pd.ProductDetailName = p.ProductDetailName;
                        pd.ProductDetailPrice = p.ProductDetailPrice;
                        pd.DetailPriceDiscount = p.DetailPriceDiscount;
                        pd.DetailStock = p.DetailStock;
                        pd.ProductId = product.ProductId;
                        context.ProductDetails.Add(pd);
                        context.SaveChanges();
                    }
                }
            }
        }

        public IEnumerable<Product> GetProductByCateId(int id)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                var productExist = context.Products.Where(x => x.CategoryId == id && x.Status == 1).ToList();
                if (productExist != null)
                {
                    return productExist;
                }
                return null;
            }
        }

        public object GetProductsAll()
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                return context.Products.Where(x => x.Status == 1).ToList();
            }
        }
    }
}
