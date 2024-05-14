using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public partial class claim
    {
        public decimal? id { get; set; }
        public string? code { get; set; }
        public string? code_ref { get; set; }
        public decimal? policy_id { get; set; }
        public string? policy_code { get; set; }
        public string? certificate_no { get; set; }
        public decimal? class_id { get; set; }
        public decimal? business_type_id { get; set; }
        public decimal? system_type_id { get; set; }
        public decimal? creator_id { get; set; }
        public decimal? surveyor_id { get; set; }
        public decimal? unit_id { get; set; }
        public decimal? unit_policy_id { get; set; }
        public decimal? closed_staff_id { get; set; }
        public decimal? unclosed_staff_id { get; set; }
        public DateTime? valid_begin_date { get; set; }
        public DateTime? valid_end_date { get; set; }
        public DateTime? loss_date { get; set; }
        public DateTime? report_date { get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? modified_date { get; set; }
        public DateTime? closed_date { get; set; }
        public DateTime? unclosed_date { get; set; }
        public decimal? customer_id { get; set; }
        public string? contact_name { get; set; }
        public string? contact_tel { get; set; }
        public decimal? claim_status_id { get; set; }
        public decimal? authority_id { get; set; }
        public string? location_of_loss { get; set; }
        public decimal? province_id { get; set; }
        public decimal? district_id { get; set; }
        public string? description { get; set; }
        public string? description_object { get; set; }
        public string? description_extent_loss { get; set; }
        public decimal? adjuster_id { get; set; }
        public string? summary_of_settlement { get; set; }
        public string? summary_of_claim_document { get; set; }
        public decimal? is_bidv { get; set; }
        public string? deductible { get; set; }
        public decimal? currency_id { get; set; }
        public string? premium_paid_date { get; set; }
        public decimal? gara_id { get; set; }
        public string? total_of_death { get; set; }
        public string? total_of_injured { get; set; }
        public decimal? reinsured_id { get; set; }
        public decimal? reinsured_rate { get; set; }
        public decimal? total_sum_insured { get; set; }
        public decimal? total_premium { get; set; }
        public decimal? total_si_reins { get; set; }
        public decimal? total_net_si_reins { get; set; }
        public decimal? total_reserve { get; set; }
        public decimal? total_net_reserve_coins { get; set; }
        public decimal? total_net_reserve_reins { get; set; }
        public decimal? total_paid { get; set; }
        public decimal? total_net_paid_coins { get; set; }
        public decimal? total_net_paid_reins { get; set; }
        public decimal? total_advance { get; set; }
        public decimal? total_net_advance_coins { get; set; }
        public decimal? total_net_advance_reins { get; set; }
        public decimal? total_adjustment_fee { get; set; }
        public decimal? total_net_adjustment_fee_coins { get; set; }
        public decimal? total_net_adjustment_fee_reins { get; set; }
        public DateTime? ngay_gui_hs_thu_doi_tbh { get; set; }
        public DateTime? ngay_gui_hs_thu_doi_dbh { get; set; }
        public DateTime? ngay_gui_hs_thu_doi_nguoi_bh { get; set; }
        public bool? dang_thu_doi_ben_thu3 { get; set; }
        public bool? denied_claim { get; set; }
        public bool? guarantee { get; set; }
        public string? node { get; set; }
        public bool? active { get; set; }
        public int? allow_update_reserve { get; set; }
        public int? allow_update_claim { get; set; }
        public int? allow_update_claim_type_process { get; set; }
        public int? allow_update_reserve_mv_mvl { get; set; }
        public decimal? driver_id { get; set; }
        public decimal? causes_accidents_id { get; set; }
        public DateTime? date_requirement_claim { get; set; }
        public Guid? id_ref { get; set; }
        public decimal? surveyor_ho_id { get; set; }
        public decimal? underwriter_id { get; set; }
        public decimal? source_id { get; set; }
        public decimal? vehicle_type_id { get; set; }
        public decimal? use_purpose_id { get; set; }
        public bool? field_inspection { get; set; }
        public string? extent_of_the_loss { get; set; }
        public string? mvcertificate_no { get; set; }
        public string? mvplate_no { get; set; }
        public string? mvmodel { get; set; }
        public string? mvengine_no { get; set; }
        public string? mvrisk { get; set; }
        public string? mvdriver { get; set; }
        public string? mvdriver_tel { get; set; }
        public DateTime? mvuse_date { get; set; }
        public DateTime? mvexpiry_date { get; set; }
        public string? mvdriver_license { get; set; }
        public string? mvthir_driver { get; set; }
        public string? mvthird_driver_tel { get; set; }
        public string? mvthird_plate_no { get; set; }
        public decimal? mvpaid_death { get; set; }
        public decimal? mvpaid_third_material { get; set; }
        public decimal? mvpaid_medical { get; set; }
        public decimal? mvpaid_material { get; set; }
        public decimal? mvpaid_service { get; set; }
        public decimal? mvtotal_paid { get; set; }
        public decimal? agency_id { get; set; }
        public string? timeloss { get; set; }
    }
}
