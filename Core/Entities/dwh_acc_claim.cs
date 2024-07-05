using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class dwh_acc_claim
    {
        public decimal? id { get; set; }
        public Guid? id_referenct { get; set; }
        public decimal? id_ref { get; set; }
        public decimal? unit_id { get; set; }
        public decimal? underwriting_form_id { get; set; }
        public string? underwriting_form_code { get; set; }
        public decimal? customer_id { get; set; }
        public string? customer_code { get; set; }
        public string? code { get; set; }
        public decimal? currency_id { get; set; }
        public string? currency_code { get; set; }
        public decimal? policy_id { get; set; }
        public string? policy_code { get; set; }
        public DateTime? loss_date { get; set; }
        public DateTime? report_date { get; set; }
        public string? loss_description { get; set; }
        public DateTime? from_date { get; set; }
        public DateTime? to_date { get; set; }
        public DateTime? created_date { get; set; }
        public decimal? created_by { get; set; }
        public DateTime? modified_date { get; set; }
        public decimal? modified_by { get; set; }
        public short? finance_year { get; set; }
        public decimal? application_id { get; set; }
        public string? application_code { get; set; }
        public decimal? policy_system_type_id { get; set; }
        public decimal? department_id { get; set; }
        public string? class_code { get; set; }
        public decimal? class_id { get; set; }
    }
}
