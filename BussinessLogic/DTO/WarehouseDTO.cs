using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessLogic.DTO
{
    public class WarehouseDTO
    {
        public int WarehouseId { get; set; }
        public int ImportProduct { get; set; }
        public int ExportProduct { get; set; }
        public double Profit { get; set; }
        public DateTime WarehouseDate { get; set; }
        public int UserId { get; set; }
    }
}
