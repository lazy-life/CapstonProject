using BussinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.IService
{
    public interface ICartService
    {
        List<CartDTO> GetCartByUserID(int id);
        void AddCartByUserID(int usId, int productId, int detailProductId, int amount);
        void DeleteCartById(int id);
        void UpdateCartById(int id, int amount);

    }
}
