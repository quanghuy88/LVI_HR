using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_acc_voucher
    {
        public decimal? id { get; set; }
        public decimal? unit_id { get; set; }
        public decimal? operation_id { get; set; }
        public string? post_number { get; set; }
        public DateTime? post_date { get; set; }
        public string? document_number { get; set; }
        public decimal? voucher_type_id { get; set; }
        public DateTime? document_date { get; set; }
        public decimal? currency_id { get; set; }
        public decimal? real_rate { get; set; }
        public decimal? account_rate { get; set; }
        public string? object_name { get; set; }
        public string? object_unit { get; set; }
        public string? object_address { get; set; }
        public string? content { get; set; }
        public DateTime? date { get; set; }
        public decimal? total_foreign_money { get; set; }
        public decimal? total_original_money { get; set; }
        public decimal? voucher_status_id { get; set; }
        public string? reason { get; set; }
        public DateTime? approve_date { get; set; }
        public decimal? approve_by { get; set; }
        public decimal? account_month_id { get; set; }
        public decimal? voucher_old_id { get; set; }
        public DateTime? created_date { get; set; }
        public decimal? created_by { get; set; }
        public DateTime? modified_date { get; set; }
        public decimal? modified_by { get; set; }
        public short? finance_year { get; set; }
        public string? ref_number { get; set; }
        public Guid? PK_VOUCHER { get; set; }
    }
}
