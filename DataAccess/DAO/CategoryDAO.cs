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
                return context.Categories.ToList();
            }
        }

        public void AddCategory(Category category)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                context.Categories.Add(category);
            }
        }
    }
}
