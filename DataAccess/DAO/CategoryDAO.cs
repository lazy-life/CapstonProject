using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class CategoryDAO
    {
        public IEnumerable<Category> GetCategories()
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                return context.Categories.Where(x => x.Status == 1).ToList();
            }
        }

        public void RemoveCategory(int id)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
               var exist = context.Categories.FirstOrDefault(x => x.CategoryId == id && x.Status == 1);
                if (exist != null)
                {
                    exist.Status = 2;
                    context.SaveChanges();
                }
            }
        }

        public void AddCategory(Category category)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                category.Status = 1;
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }
    }
}
