using BussinessLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.IService
{
    public interface ICategoryService
    {
        List<CategoryDTO> GetProducts();
    }
}
