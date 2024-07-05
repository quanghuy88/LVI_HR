using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_revenue_month_branch
    {
        public decimal id { get; set; }
        public decimal branch_id { get; set; }
        public string? account_year { get; set; }
        public int account_month { get; set; }
        public decimal foreign_revenue_money { get; set; }
        public decimal exchange_revenue_money { get; set; }
        public decimal foreign_profit_money { get; set; }
        public decimal exchange_profit_money { get; set; }
        public decimal foreign_compensation_money { get; set; }
        public decimal exchange_compensation_money { get; set; }
    }
}
