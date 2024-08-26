using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public partial class dwh_revenue_profit_target
    {
        public decimal id { get; set; }
        public decimal target { get; set; }
        public string target_name { get; set; }
        public decimal branch_id { get; set; }
        public string account_month { get; set; }
        public string account_year { get; set; }
        public string type_target { get; set; }
        public decimal class_group_id { get; set; }
    }
}
