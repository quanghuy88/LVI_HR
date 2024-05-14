using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public partial class revenue_plan
    {
        public decimal id { get; set; }
        public string? code { get; set; }
        public string? name { get; set; }
        public decimal? productid { get; set; }
        public decimal? branchid { get; set; }
        public string? type { get; set; }
        public decimal? revenue { get; set; }
        public DateTime? fromdate { get; set; }
        public DateTime? todate { get; set; }
    }
}
