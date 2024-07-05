using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_acc_claim_process_detail
    {
        public decimal? id { get; set; }
        public decimal? account_month_id { get; set; }
        public decimal? claim_proccess_id { get; set; }
        public decimal? auto_posting_id { get; set; }
        public string? auto_posting_code { get; set; }
        public decimal? domain_id { get; set; }
        public string? domain_code { get; set; }
        public decimal? contract_id { get; set; }
        public string? contract_code { get; set; }
        public decimal? amount_money { get; set; }
        public decimal? reinsurance_rate { get; set; }
        public string? description { get; set; }
        public int? sequence { get; set; }
    }
}
