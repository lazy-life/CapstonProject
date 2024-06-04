using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessLogic.DTO
{
    public class HistoryDTO
    {
        public int HistoryId { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
    }
}
