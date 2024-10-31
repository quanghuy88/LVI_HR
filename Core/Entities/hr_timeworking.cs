using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public partial class hr_timeworking
    {
        public decimal id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string inhour { get; set; }
        public string inminute { get; set; }
        public string insecond { get; set; }
        public string outhour { get; set; }
        public string outminute { get; set; }
        public string outsecond { get; set; }
        public string description { get; set; }

    }
}
