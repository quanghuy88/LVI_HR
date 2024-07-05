using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_fact_branch_cg_month
    {
        public decimal id { get; set; }
        public decimal branch_id { get; set; }
        public string class_group_code { get; set; }
        public int? account_year { get; set; }
        public int account_month { get; set; }
        public decimal foreign_revenue_money { get; set; }
        public decimal exchange_revenue_money { get; set; }
        public decimal foreign_non_retention_compensation_money { get; set; }
        public decimal exchange_non_retention_compensation_money { get; set; }
        public decimal foreign_total_compensation_money { get; set; }
        public decimal exchange_total_compensation_money { get; set; }
        public DateTime? datadate { get; set; }
        public int int_datadate { get; set; }
    }
}
