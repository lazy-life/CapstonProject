using BussinessLogic.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.IService
{
    public interface IUserService
    {
        List<UserDTO> GetUsers();
    }
}
