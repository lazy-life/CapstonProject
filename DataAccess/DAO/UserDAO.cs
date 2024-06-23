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
            using (DataAccessContext context = new DataAccessContext())
            {
                return context.Users.ToList();
            }
        }

        public User Authentication(string username, string password)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                return context.Users.FirstOrDefault(x => x.UserEmail.Equals(username) && x.UserPassword.Equals(password));
            }

        }
        public User GetUserById(int id)
        {
            using (DataAccessContext context = new DataAccessContext())
            {
                return context.Users.FirstOrDefault(x => x.UserId == id);
            }
        }
    }
}
