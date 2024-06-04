using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessLogic.DTO
{
    public class CartDTO
    {
        public int CartId { get; set; }
        public DateTime CartDate { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int ProductDetailId { get; set; }
    }
}
