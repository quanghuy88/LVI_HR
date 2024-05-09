using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public partial class insurance_product
    {
        public decimal id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string en_name { get; set; }
        public decimal insurance_product_group_id { get; set; }
        public Nullable<decimal> insurance_product_group_level_one_id { get; set; }
        public Nullable<decimal> division_id { get; set; }
        public Nullable<decimal> agent_commission_rate { get; set; }
        public Nullable<decimal> agent_support_rate { get; set; }
        public Nullable<decimal> agent_commision_tax_rate { get; set; }
        public Nullable<decimal> broker_commission_rate { get; set; }
        public Nullable<decimal> factor { get; set; }
        public Nullable<int> sequence { get; set; }
        public bool status { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public Nullable<decimal> created_by { get; set; }
        public Nullable<System.DateTime> modified_date { get; set; }
        public Nullable<decimal> modified_by { get; set; }
        public Nullable<bool> is_renew { get; set; }
        public Nullable<bool> is_show { get; set; }
        public Nullable<bool> first_loss { get; set; }
    }
}
