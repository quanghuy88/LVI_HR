using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_acc_policy
    {
        public decimal? id { get; set; }
        public Guid? id_reference { get; set; }
        public decimal? application_id { get; set; }
        public string? application_code { get; set; }
        public decimal? unit_id { get; set; }
        public string? underwriting_form_code { get; set; }
        public decimal? underwriter_id { get; set; }
        public string? code { get; set; }
        public string? class_code { get; set; }
        public DateTime? from_date { get; set; }
        public DateTime? to_date { get; set; }
        public DateTime? closed_date { get; set; }
        public decimal? form_id { get; set; }
        public string? form_code { get; set; }
        public decimal? source_id { get; set; }
        public string? source_code { get; set; }
        public decimal? customer_id { get; set; }
        public string? customer_code { get; set; }
        public decimal? payer_id { get; set; }
        public string? payer_code { get; set; }
        public decimal? agent_id { get; set; }
        public string? agent_code { get; set; }
        public decimal? broker_id { get; set; }
        public string? broker_code { get; set; }
        public string? risk_code { get; set; }
        public decimal? currency_id { get; set; }
        public string? currency_code { get; set; }
        public decimal? sum_insured { get; set; }
        public decimal? total_premium_money { get; set; }
        public decimal? total_vat_money { get; set; }
        public decimal? total_money { get; set; }
        public decimal? commission_rate { get; set; }
        public decimal? total_commission_money { get; set; }
        public bool? status { get; set; }
        public DateTime? created_date { get; set; }
        public decimal? created_by { get; set; }
        public DateTime? modified_date { get; set; }
        public decimal? modified_by { get; set; }
        public string? underwriting_month { get; set; }
        public short? underwriting_year { get; set; }
        public decimal? id_ref { get; set; }
        public decimal? policy_system_id { get; set; }
        public decimal? policy_system_type_id { get; set; }
        public decimal? department_id { get; set; }
    }
}
