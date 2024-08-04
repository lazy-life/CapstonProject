using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressID { get; set; }
        public int UserId { get; set; }
        public string Matp { get; set; }
        public string Maqh { get; set; }
        public string Mapx { get; set; }
        public string Detail { get; set; }
    }
}
