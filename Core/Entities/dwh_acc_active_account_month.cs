using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_acc_active_account_month
    {
        public decimal account_month_id { get; set; }
        public decimal next_month_id { get; set; }
        public DateTime? active_date { get; set; }
        public DateTime? finish_date { get; set; }
        public bool? status { get; set; }
        public DateTime? created_date { get; set; }
        public decimal? created_by { get; set; }
        public DateTime? modified_date { get; set; }
        public decimal? modified_by { get; set; }
    }
}
