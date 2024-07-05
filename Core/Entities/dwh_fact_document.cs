using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_fact_document
    {
        public decimal id { get; set; }
        public DateTime datadate { get; set; }
        public decimal unit_id { get; set; }
        public string? account_year { get; set; }
        public int account_month { get; set; }
        public string? co_code { get; set; }
        public decimal class_code { get; set; }
        public int? major_class { get; set; }
        public string? debit_account_id { get; set; }
        public string? credit_account_id { get; set; }
        public int? department_id { get; set; }
        public int? underwriter_id { get; set; }
        public decimal foreign_money { get; set; }
        public decimal exchange_money { get; set; }
    }
}
