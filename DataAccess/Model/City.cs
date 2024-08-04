using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class City
    {
        [Key]
        public string Matp { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Slug { get; set; }
    }
}
