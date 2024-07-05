using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_cfig_report_month
    {
        public int id { get; set; }
        public int? reportyear { get; set; }
        public string? reportmonths { get; set; }
        public string? closedmonths { get; set; }
        public int? status { get; set; }
        public int? type { get; set; }
        public string? remark { get; set; }
    }
}
