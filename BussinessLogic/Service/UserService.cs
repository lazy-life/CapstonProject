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
        public UserDTO AuthenticationUser(string userName, string password)
        {
            return _mapper.Map<UserDTO>(_userDAO.Authentication(userName, password));
        }

        public UserDTO GetUserById(int id)
        {
            return _mapper.Map<UserDTO>(_userDAO.GetUserById(id));
        }
    }
}
