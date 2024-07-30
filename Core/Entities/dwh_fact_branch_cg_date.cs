using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_fact_branch_cg_date
    {
        public decimal id { get; set; }
        public decimal branch_id { get; set; }
        public string? class_group_code { get; set; }
        public int? account_year { get; set; }
        public int account_month { get; set; }
        public decimal foreign_money { get; set; }
        public decimal original_money { get; set; }
        public DateTime? datadate { get; set; }
        public int int_datadate { get; set; }
        public string code_order { get; set; }
    }
}
