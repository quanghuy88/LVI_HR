using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_fact_branch_class_date
    {
        public decimal id { get; set; }
        public decimal branch_id { get; set; }
        public decimal? class_code { get; set; }
        public string? account_year { get; set; }
        public int account_month { get; set; }
        public decimal foreign_revenue_money { get; set; }
        public decimal exchange_revenue_money { get; set; }
        public DateTime? datadate { get; set; }
    }
}
