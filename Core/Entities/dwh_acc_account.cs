using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_acc_account
    {
        public decimal? id { get; set; }
        public decimal? parent_id { get; set; }
        public string? code { get; set; }
        public string? code_ref { get; set; }
        public string? name { get; set; }
        public string? name_en { get; set; }
        public string? name_other { get; set; }
        public int? level { get; set; }
        public string? note { get; set; }
        public decimal? unit_id { get; set; }
        public decimal? rate_type_id { get; set; }
        public decimal? account_type_id { get; set; }
        public decimal? account_property_id { get; set; }
        public decimal? currency_id { get; set; }
        public short? finance_year { get; set; }
        public bool? status { get; set; }
        public DateTime? created_date { get; set; }
        public decimal? created_by { get; set; }
        public DateTime? modified_date { get; set; }
        public decimal? modified_by { get; set; }
        public string? code_bs { get; set; }
        public string? code_pl { get; set; }
        public string? code_pl2 { get; set; }
        public bool? is_policy { get; set; }
        public bool? is_claim { get; set; }
        public string? name_lao { get; set; }
        public string? code_lao { get; set; }
    }
}
