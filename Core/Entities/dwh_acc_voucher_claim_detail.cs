using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_acc_voucher_claim_detail
    {
        public string? id { get; set; }
        public decimal? voucher_id { get; set; }
        public decimal? debit_account_id { get; set; }
        public decimal? debit_claim_code { get; set; }
        public decimal? debit_policy_code { get; set; }
        public decimal? debit_domain_id { get; set; }
        public decimal? credit_account_id { get; set; }
        public decimal? credit_claim_code { get; set; }
        public decimal? credit_policy_code { get; set; }
        public decimal? credit_domain_id { get; set; }
        public decimal? currency_id { get; set; }
        public decimal? foreign_money { get; set; }
        public decimal? original_money { get; set; }
        public decimal? unequal_money { get; set; }
        public string? description { get; set; }
        public short? finance_year { get; set; }
        public decimal? currency_rate { get; set; }
        public decimal? debit_dept_id { get; set; }
        public decimal? credit_dept_id { get; set; }
        public decimal? debit_resource_id { get; set; }
        public decimal? credit_resource_id { get; set; }
        public decimal? currency_code { get; set; }
        public decimal? debit_class_code { get; set; }
        public decimal? credit_class_code { get; set; }
        public decimal? voucher_detail_id { get; set; }
        public decimal? debit_policy_instalment_id { get; set; }
        public decimal? credit_policy_instalment_id { get; set; }
        public decimal? debit_claim_proccess_id { get; set; }
        public decimal? credit_claim_proccess_id { get; set; }
        public DateTime? datadate { get; set; }
    }
}
