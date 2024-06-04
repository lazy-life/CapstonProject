using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class UserDAO
    {
        public IEnumerable<User> GetUsers()
        {
            using(DataAccessContext context = new DataAccessContext())
            {
                return context.Users.ToList();
            }
        }
    }
}
