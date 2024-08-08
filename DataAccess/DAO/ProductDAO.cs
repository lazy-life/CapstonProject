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
                context.Products.Add(product);
                context.SaveChanges();

                foreach (var p in productDetail)
                {
                    var pd = new ProductDetail();
                    pd.ProductDetailName = p.ProductDetailName;
                    pd.ProductDetailPrice = p.ProductDetailPrice;
                    pd.DetailPriceDiscount = p.DetailPriceDiscount;
                    pd.StartDate = p.StartDate;
                    pd.DetailStock = p.DetailStock;
                    pd.EndDate = p.EndDate;
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
                    //productExist.ProductName = product.ProductName;
                    //productExist.ProductPrice = product.ProductPrice;
                    //productExist.ProductSalePrice = product.ProductSalePrice;
                    //productExist.ProductCost = product.ProductCost;
                    //productExist.CategoryId = product.CategoryId;
                    //productExist.UserId = product.UserId;
                    //productExist.UpdateAt = DateTime.Now;

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
                exist.Img1 = product.Img1 != "" ? product.Img1  : exist.Img1;
                exist.Img2 = product.Img2 != "" ? product.Img2  : exist.Img2; ;
                exist.Img3 = product.Img3 != "" ? product.Img3  : exist.Img3;;
                exist.Img4 = product.Img4 != "" ? product.Img4  : exist.Img4;;
                exist.Img5 = product.Img5 != "" ? product.Img5  : exist.Img5;;
                context.SaveChanges();

                foreach (var p in productDetails)
                {
                    if (p.ProductDetailId == 0)
                    {
                        var pd = new ProductDetail();
                        pd.ProductDetailName = p.ProductDetailName;
                        pd.ProductDetailPrice = p.ProductDetailPrice;
                        pd.DetailPriceDiscount = p.DetailPriceDiscount;
                        pd.StartDate = p.StartDate;
                        pd.DetailStock = p.DetailStock;
                        pd.EndDate = p.EndDate;
                        pd.ProductId = product.ProductId;
                        context.ProductDetails.Add(pd);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
