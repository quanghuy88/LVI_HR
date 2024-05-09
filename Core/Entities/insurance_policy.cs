using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public partial class insurance_policy
    {
        public decimal id { get; set; }
        public string code { get; set; }
        public string related_code { get; set; }
        public decimal underwriter_id { get; set; }
        public decimal creator_id { get; set; }
        public Nullable<decimal> handler_id { get; set; }
        public Nullable<decimal> department_id { get; set; }
        public decimal unit_id { get; set; }
        public Nullable<decimal> approver_id { get; set; }
        public Nullable<decimal> real_approver_id { get; set; }
        public Nullable<decimal> reinsurance_staff_id { get; set; }
        public Nullable<decimal> closed_staff_id { get; set; }
        public Nullable<decimal> system_id { get; set; }
        public decimal class_id { get; set; }
        public Nullable<decimal> customer_id { get; set; }
        public decimal payer_id { get; set; }
        public decimal currency_id { get; set; }
        public decimal issue_form_id { get; set; }
        public decimal business_type_id { get; set; }
        public Nullable<int> valid_begin_minutes { get; set; }
        public Nullable<int> valid_begin_hours { get; set; }
        public System.DateTime valid_begin_date { get; set; }
        public Nullable<int> valid_end_minutes { get; set; }
        public Nullable<int> valid_end_hours { get; set; }
        public System.DateTime valid_end_date { get; set; }
        public Nullable<System.DateTime> effectived_date { get; set; }
        public System.DateTime issue_date { get; set; }
        public Nullable<System.DateTime> submit_date { get; set; }
        public Nullable<System.DateTime> approver_date { get; set; }
        public Nullable<System.DateTime> closed_date { get; set; }
        public Nullable<System.DateTime> reinsurance_date { get; set; }
        public decimal policy_status_id { get; set; }
        public decimal approver_status_id { get; set; }
        public decimal reinsurance_status_id { get; set; }
        public decimal cancel_status_id { get; set; }
        public decimal changing_status_id { get; set; }
        public Nullable<int> changing_no { get; set; }
        public decimal account_month_id { get; set; }
        public string account_month { get; set; }
        public int underwriting_year { get; set; }
        public Nullable<decimal> total_sum_insured { get; set; }
        public Nullable<decimal> total_premium { get; set; }
        public Nullable<decimal> total_premium_other { get; set; }
        public Nullable<decimal> total_vat { get; set; }
        public Nullable<decimal> total_premium_vat { get; set; }
        public string refused_reason { get; set; }
        public Nullable<decimal> agent_id { get; set; }
        public Nullable<decimal> agent_commission_rate { get; set; }
        public Nullable<decimal> broker_id { get; set; }
        public Nullable<decimal> broker_commission_rate { get; set; }
        public Nullable<decimal> total_commission { get; set; }
        public Nullable<decimal> total_commission_tax { get; set; }
        public Nullable<decimal> reinsured_id { get; set; }
        public Nullable<decimal> reinsured_commission_rate { get; set; }
        public Nullable<decimal> reinsured_commission { get; set; }
        public Nullable<decimal> bic_join_rate { get; set; }
        public string deductible { get; set; }
        public Nullable<decimal> table_of_risk_catogories_id { get; set; }
        public string description_of_risk { get; set; }
        public string location { get; set; }
        public Nullable<decimal> district_id { get; set; }
        public Nullable<decimal> province_id { get; set; }
        public Nullable<decimal> source_id { get; set; }
        public string introducer { get; set; }
        public Nullable<decimal> pay_at_id { get; set; }
        public Nullable<decimal> total_bic_net_reinsurance_rate { get; set; }
        public Nullable<decimal> total_bic_net_reinsurance_si { get; set; }
        public Nullable<decimal> total_bic_net_reinsurance_premium { get; set; }
        public Nullable<decimal> total_bic_net_reinsurance_commission { get; set; }
        public Nullable<decimal> total_bic_net_engineering_fee { get; set; }
        public Nullable<decimal> total_premium_exchange { get; set; }
        public bool active { get; set; }
        public System.DateTime created_date { get; set; }
        public Nullable<System.DateTime> modifided_date { get; set; }
        public Nullable<decimal> total_voluntary_liability_premium { get; set; }
        public Nullable<decimal> total_compulsory_liability_premium { get; set; }
        public Nullable<decimal> total_accident_for_passenger_premium { get; set; }
        public Nullable<decimal> total_fire_explosion_premium { get; set; }
        public Nullable<decimal> total_voluntary_for_damage_si { get; set; }
        public Nullable<decimal> total_sum_insured_all { get; set; }
        public Nullable<decimal> total_premium_all { get; set; }
        public Nullable<decimal> total_premium_other_all { get; set; }
        public Nullable<decimal> total_vat_all { get; set; }
        public Nullable<decimal> total_premium_vat_all { get; set; }
        public Nullable<decimal> total_commission_all { get; set; }
        public string Reason { get; set; }
        public Nullable<decimal> renew_status_id { get; set; }
        public string reason_renew { get; set; }
        public string Remedy_renew { get; set; }
        public Nullable<System.DateTime> renew_date { get; set; }
        public Nullable<decimal> total_premium_paid { get; set; }
        public Nullable<decimal> total_claim_paid { get; set; }
        public Nullable<System.Guid> id_ref { get; set; }
        public Nullable<decimal> renew_policy_id { get; set; }
        public string renew_policy_code { get; set; }
        public Nullable<decimal> renew_underwriter_id { get; set; }
        public Nullable<decimal> renew_total_si { get; set; }
        public Nullable<decimal> renew_total_pre { get; set; }
        public string code_original { get; set; }
        public Nullable<bool> is_typhoon_flood { get; set; }
        public Nullable<bool> policy_final { get; set; }
        public Nullable<bool> is_closed { get; set; }
        public Nullable<decimal> total_premium_other_cost { get; set; }
        public Nullable<decimal> total_premium_other_cost_all { get; set; }
        public Nullable<bool> is_bidding { get; set; }
        public Nullable<int> payment_type_id { get; set; }
        public Nullable<decimal> total_premium_other_DPHCTT { get; set; }
        public Nullable<decimal> total_premium_other_DPHCTT_all { get; set; }
        public string list_of_coinsurer_share { get; set; }
        public string total_coinsurance_leeding_fee { get; set; }
        public Nullable<decimal> total_pre_premium_all { get; set; }
        public Nullable<decimal> total_pre_premium { get; set; }
        public string note { get; set; }
        public Nullable<decimal> id_policy_ref { get; set; }
        public string package { get; set; }
    }
}
