using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DTO
{
    public class OrderRequest
    {
        public Order Orders { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
