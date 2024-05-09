using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public partial class fact_date
    {
        public decimal id { get; set; }
        public Nullable<decimal> branchid { get; set; }
        public Nullable<decimal> classid { get; set; }
        public Nullable<System.DateTime> createdate { get; set; }
        public Nullable<int> type { get; set; }
        public Nullable<decimal> totalmoney { get; set; }
    }
}
