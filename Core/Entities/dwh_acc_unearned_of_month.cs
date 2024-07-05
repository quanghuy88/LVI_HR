using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_acc_unearned_of_month
    {
        public decimal? id { get; set; }
        public decimal? unearned_listing_id { get; set; }
        public decimal? voucher_id { get; set; }
        public decimal? account_month_id { get; set; }
        public string? transaction_code { get; set; }
        public string? type { get; set; }
        public string? underwriting_form_code { get; set; }
        public decimal? foreign_unearned { get; set; }
        public decimal? exchange_unearned { get; set; }
        public decimal? foreign_earned { get; set; }
        public decimal? exchange_earned { get; set; }
        public string? debit_account_code { get; set; }
        public string? credit_account_code { get; set; }
        public DateTime? from_date { get; set; }
        public DateTime? to_date { get; set; }
        public DateTime? created_date { get; set; }
        public decimal? created_by { get; set; }
    }
}
