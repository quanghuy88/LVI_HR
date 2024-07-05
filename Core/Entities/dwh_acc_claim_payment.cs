using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_acc_claim_payment
    {
        public decimal? id { get; set; }
        public decimal? claim_proccess_id { get; set; }
        public decimal? claim_proccess_detail_id { get; set; }
        public string? claim_code { get; set; }
        public string? policy_code { get; set; }
        public decimal? instalment_number { get; set; }
        public decimal? domain_id { get; set; }
        public decimal? currency_id { get; set; }
        public decimal? instalment_month { get; set; }
        public decimal? account_month { get; set; }
        public decimal? voucher_id { get; set; }
        public decimal? accountant_id { get; set; }
        public decimal? account_payment_id { get; set; }
        public decimal? premium_money { get; set; }
        public decimal? vat_money { get; set; }
        public decimal? total_payment_money { get; set; }
        public decimal? total_payment_money_exchange { get; set; }
        public decimal? payment_money { get; set; }
        public decimal? payment_money_exchange { get; set; }
        public decimal? balance_money { get; set; }
        public decimal? balance_money_exchange { get; set; }
        public DateTime? created_date { get; set; }
        public decimal? currency_rate { get; set; }
    }
}
