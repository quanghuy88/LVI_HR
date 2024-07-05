using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_acc_auto_posting
    {
        public decimal? id { get; set; }
        public decimal? operation_id { get; set; }
        public string? code { get; set; }
        public string? name { get; set; }
        public string? name_other { get; set; }
        public decimal? code_order_id { get; set; }
        public decimal? account_debit_id { get; set; }
        public string? account_debit_code { get; set; }
        public decimal? account_credit_id { get; set; }
        public string? account_credit_code { get; set; }
        public decimal? account_policy_id { get; set; }
        public string? account_policy_code { get; set; }
        public string? type { get; set; }
        public string? note { get; set; }
        public int? sequence { get; set; }
        public bool? status { get; set; }
        public bool? is_deleted { get; set; }
        public DateTime? created_date { get; set; }
        public decimal? created_by { get; set; }
        public DateTime? modified_date { get; set; }
        public decimal? modified_by { get; set; }
    }
}
