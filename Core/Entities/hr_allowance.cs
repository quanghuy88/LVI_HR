using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public partial class hr_allowance
    {
        public decimal id { get; set; }
        public string code { get; set; }
        public int type { get; set; }
        public string name { get; set; }
        public decimal amount { get; set; }
        public string description { get; set; }
        public int sequence { get; set; }
        public bool? status { get; set; }
    }
}
