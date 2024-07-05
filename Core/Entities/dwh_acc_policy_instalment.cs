using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_acc_policy_instalment
    {
        public decimal? id { get; set; }
        public decimal? policy_id { get; set; }
        public decimal? instalment_number { get; set; }
        public decimal? instalment_month_id { get; set; }
        public decimal? voucher_id { get; set; }
        public decimal? invoice_id { get; set; }
        public decimal? status_id { get; set; }
        public Guid? instalment_id_ref { get; set; }
        public decimal? month_of_revenue_recognition { get; set; }
        public decimal? real_rate { get; set; }
        public decimal? premium_money { get; set; }
        public decimal? vat_money { get; set; }
        public decimal? money_of_payment_premium { get; set; }
        public DateTime? date_of_payment_premium { get; set; }
        public DateTime? period_paid { get; set; }
        public decimal? commission_money { get; set; }
        public decimal? money_of_payment_commission { get; set; }
        public DateTime? date_of_payment_commission { get; set; }
        public decimal? old_id { get; set; }
        public decimal? retention_rate { get; set; }
        public decimal? instalment_id_biccare_ref { get; set; }
        public string? type { get; set; }
        public string? invoice_no { get; set; }
        public DateTime? invoice_date { get; set; }
        public string? serial_no { get; set; }
        public decimal? premium_management_fee { get; set; }
    }
}
