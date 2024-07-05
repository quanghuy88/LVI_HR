using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_list_insurance_product
    {
        public decimal? id { get; set; }
        public string? code { get; set; }
        public string? name { get; set; }
        public string? en_name { get; set; }
        public decimal? insurance_product_group_id { get; set; }
        public decimal? insurance_product_group_level_one_id { get; set; }
        public decimal? division_id { get; set; }
        public decimal? agent_commission_rate { get; set; }
        public decimal? agent_support_rate { get; set; }
        public decimal? agent_commision_tax_rate { get; set; }
        public decimal? broker_commission_rate { get; set; }
        public decimal? factor { get; set; }
        public int? sequence { get; set; }
        public bool? status { get; set; }
        public DateTime? created_date { get; set; }
        public decimal? created_by { get; set; }
        public DateTime? modified_date { get; set; }
        public decimal? modified_by { get; set; }
        public bool? is_renew { get; set; }
        public bool? is_show { get; set; }
        public bool? first_loss { get; set; }
    }
}
