using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_acc_unearned_listing
    {
        public decimal? id { get; set; }
        public decimal? unit_id { get; set; }
        public string? policy_code { get; set; }
        public decimal? policy_instalment_id { get; set; }
        public decimal? instalment_month { get; set; }
        public short? instalment_number { get; set; }
        public decimal? account_month { get; set; }
        public string? _class { get; set; }
        public DateTime? from_date { get; set; }
        public DateTime? to_date { get; set; }
        public int? days_of_policy { get; set; }
        public string? transaction_code { get; set; }
        public decimal? currency_id { get; set; }
        public string? currency_code { get; set; }
        public decimal? currency_rate { get; set; }
        public decimal? foreign_money { get; set; }
        public decimal? exchange_money { get; set; }
        public DateTime? created_date { get; set; }
        public decimal? created_by { get; set; }
        public short? finance_year { get; set; }
        public decimal? is_deleted { get; set; }
        public decimal? voucher_id { get; set; }
        public decimal? domain_id { get; set; }
        public string? account_code { get; set; }
        public string? underwriting_form_code { get; set; }
    }
}
