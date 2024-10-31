using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public partial class admin_place
    {
        public decimal id { get; set; }
        public string name { get; set; }
        public string postal_code { get; set; }
        public int? sequence { get; set; }
        public string description { get; set; }
    }
}
