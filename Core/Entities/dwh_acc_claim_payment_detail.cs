using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_acc_claim_payment_detail
    {
        public decimal? id { get; set; }
        public decimal? claim_payment_id { get; set; }
        public decimal? voucher_id { get; set; }
        public decimal? paid_money_amount { get; set; }
        public decimal? paid_money_amount_exchange { get; set; }
        public DateTime? created_date { get; set; }
        public decimal? created_by { get; set; }
    }
}
