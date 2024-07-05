using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_acc_claim_process
    {
        public decimal? id { get; set; }
        public decimal? claim_id { get; set; }
        public decimal? claim_process_type_id { get; set; }
        public decimal? account_month_id { get; set; }
        public decimal? voucher_id { get; set; }
        public DateTime? date_of_payment { get; set; }
        public decimal? money_of_payment { get; set; }
        public decimal? claim_process_status_id { get; set; }
        public DateTime? created_date { get; set; }
        public Guid? claim_process_ref_id { get; set; }
        public decimal? id_ref { get; set; }
        public decimal? id_ref_biccare { get; set; }
    }
}
