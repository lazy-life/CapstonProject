using AutoMapper;
using BussinessLogic.DTO;
using BussinessLogic.IService;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Service
{
    public class CartService : ICartService
    {
        private readonly IMapper _mapper;
        private readonly CartDAO _cartDAO;
        public CartService(IMapper mapper, CartDAO cartDAO)
        {
            _mapper = mapper;
            _cartDAO = cartDAO;
        }

        public void AddCartByUserID(int usId, int productId, int detailProductId, int amount)
        {
            _cartDAO.AddCartByUserID(usId, productId, detailProductId, amount);
        }

        public void DeleteCartById(int id)
        {
            _cartDAO.DeleteCartById(id);
        }

        public List<CartDTO> GetCartByUserID(int id)
        {
            return _mapper.Map<List<CartDTO>>(_cartDAO.GetCartByUserID(id));
        }

        public void UpdateCartById(int id, int amount)
        {
            _cartDAO.UpdateCartById(id, amount);
        }
    }
}
