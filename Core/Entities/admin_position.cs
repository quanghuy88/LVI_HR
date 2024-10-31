using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public partial class admin_position
    {
        public decimal id { get; set; }
        public string name { get; set; }
        public string level { get; set; }
        public int? sequence { get; set; }
    }
}
