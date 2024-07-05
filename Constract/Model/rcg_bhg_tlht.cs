using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constract.Model
{
    public class rcg_bhg_tlht
    {
        public string branch_id { get; set; }
        public string branch_name { get; set; }
        public string bhg_tlht { get; set; }
        //1: > 100%, 2 > 90%, 3< 90%
        public string type_tlht { get;set; }

    }
}
