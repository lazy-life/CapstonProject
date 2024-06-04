using AutoMapper;
using BussinessLogic.DTO;
using BussinessLogic.IService;
using DataAccess.DAO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Service
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserDAO _userDAO;
        public UserService(IMapper mapper, UserDAO userDAO)
        {
            _mapper = mapper;
            _userDAO = userDAO;
        }

        public List<UserDTO> GetUsers()
        {
            return _mapper.Map<List<UserDTO>>(_userDAO.GetUsers());
        }
    }
}
