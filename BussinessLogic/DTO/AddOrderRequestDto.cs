using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DTO
{
    public class AddOrderRequestDto
    {
        public List<OrderDTO> Items { get; set; }
    }
}
