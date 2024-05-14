using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public partial class LVIDashboardContext : DbContext
    {
        public LVIDashboardContext()
        {
        }

        public LVIDashboardContext(DbContextOptions<LVIDashboardContext> options) : base(options)
        {
        }
        public virtual DbSet<branch> branches { get; set; } = null!;
        public virtual DbSet<claim> claims { get; set; } = null!;
        public virtual DbSet<fact_date> fact_dates { get; set; } = null!;
        public virtual DbSet<insurance_policy> insurance_policies { get; set; } = null!;
        public virtual DbSet<insurance_product> insurance_products { get; set; } = null!;
        public virtual DbSet<revenue_plan> revenue_plans { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<branch>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("branch", "list");

                entity.Property(e => e.acc_no)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.account_name).HasMaxLength(120);

                entity.Property(e => e.address).HasMaxLength(200);

                entity.Property(e => e.b_function)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.bank_address).HasMaxLength(200);

                entity.Property(e => e.bank_name).HasMaxLength(120);

                entity.Property(e => e.bussiness_registration_no)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.code_ref).HasMaxLength(200);

                entity.Property(e => e.contact_address).HasMaxLength(200);

                entity.Property(e => e.contact_email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.contact_mobile)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.contact_name).HasMaxLength(120);

                entity.Property(e => e.contact_tel)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.created_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.director_name).HasMaxLength(120);

                entity.Property(e => e.domain_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.fax)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.image).HasMaxLength(200);

                entity.Property(e => e.issued_by).HasMaxLength(500);

                entity.Property(e => e.issued_date).HasColumnType("datetime");

                entity.Property(e => e.modified_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_date).HasColumnType("datetime");

                entity.Property(e => e.name).HasMaxLength(200);

                entity.Property(e => e.name_abbreviation).HasMaxLength(120);

                entity.Property(e => e.note).HasMaxLength(4000);

                entity.Property(e => e.parent_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.place_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.slogan).HasMaxLength(200);

                entity.Property(e => e.tax_code)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.tel)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.website)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<claim>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("claim", "insurance");

                entity.Property(e => e.adjuster_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.agency_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.authority_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.business_type_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.causes_accidents_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.certificate_no)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.claim_status_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.class_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.closed_date).HasColumnType("datetime");

                entity.Property(e => e.closed_staff_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.code_ref)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.contact_name).HasMaxLength(500);

                entity.Property(e => e.contact_tel).HasMaxLength(100);

                entity.Property(e => e.create_date).HasColumnType("datetime");

                entity.Property(e => e.creator_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.currency_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.customer_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.date_requirement_claim).HasColumnType("datetime");

                entity.Property(e => e.deductible).HasMaxLength(4000);

                entity.Property(e => e.description).HasMaxLength(4000);

                entity.Property(e => e.description_extent_loss).HasMaxLength(4000);

                entity.Property(e => e.description_object).HasMaxLength(4000);

                entity.Property(e => e.district_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.driver_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.extent_of_the_loss).HasMaxLength(500);

                entity.Property(e => e.gara_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.is_bidv).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.location_of_loss).HasMaxLength(4000);

                entity.Property(e => e.loss_date).HasColumnType("datetime");

                entity.Property(e => e.modified_date).HasColumnType("datetime");

                entity.Property(e => e.mvcertificate_no).HasMaxLength(200);

                entity.Property(e => e.mvdriver).HasMaxLength(200);

                entity.Property(e => e.mvdriver_license).HasMaxLength(200);

                entity.Property(e => e.mvdriver_tel).HasMaxLength(200);

                entity.Property(e => e.mvengine_no).HasMaxLength(200);

                entity.Property(e => e.mvexpiry_date).HasColumnType("datetime");

                entity.Property(e => e.mvmodel).HasMaxLength(200);

                entity.Property(e => e.mvpaid_death).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.mvpaid_material).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.mvpaid_medical).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.mvpaid_service).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.mvpaid_third_material).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.mvplate_no).HasMaxLength(200);

                entity.Property(e => e.mvrisk).HasMaxLength(200);

                entity.Property(e => e.mvthir_driver).HasMaxLength(200);

                entity.Property(e => e.mvthird_driver_tel).HasMaxLength(200);

                entity.Property(e => e.mvthird_plate_no).HasMaxLength(200);

                entity.Property(e => e.mvtotal_paid).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.mvuse_date).HasColumnType("datetime");

                entity.Property(e => e.ngay_gui_hs_thu_doi_dbh).HasColumnType("datetime");

                entity.Property(e => e.ngay_gui_hs_thu_doi_nguoi_bh).HasColumnType("datetime");

                entity.Property(e => e.ngay_gui_hs_thu_doi_tbh).HasColumnType("datetime");

                entity.Property(e => e.node).HasMaxLength(4000);

                entity.Property(e => e.policy_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.policy_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.premium_paid_date).HasMaxLength(500);

                entity.Property(e => e.province_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.reinsured_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.reinsured_rate).HasColumnType("numeric(10, 6)");

                entity.Property(e => e.report_date).HasColumnType("datetime");

                entity.Property(e => e.source_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.summary_of_claim_document).HasMaxLength(4000);

                entity.Property(e => e.summary_of_settlement).HasMaxLength(4000);

                entity.Property(e => e.surveyor_ho_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.surveyor_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.system_type_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.timeloss)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.total_adjustment_fee).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_advance).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_net_adjustment_fee_coins).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_net_adjustment_fee_reins).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_net_advance_coins).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_net_advance_reins).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_net_paid_coins).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_net_paid_reins).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_net_reserve_coins).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_net_reserve_reins).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_net_si_reins).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_of_death).HasMaxLength(50);

                entity.Property(e => e.total_of_injured).HasMaxLength(50);

                entity.Property(e => e.total_paid).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_premium).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_reserve).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_si_reins).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_sum_insured).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.unclosed_date).HasColumnType("datetime");

                entity.Property(e => e.unclosed_staff_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.underwriter_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.unit_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.unit_policy_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.use_purpose_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.valid_begin_date).HasColumnType("datetime");

                entity.Property(e => e.valid_end_date).HasColumnType("datetime");

                entity.Property(e => e.vehicle_type_id).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<fact_date>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("fact_date");

                entity.Property(e => e.branchid).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.classid).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.createdate).HasColumnType("datetime");

                entity.Property(e => e.id)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.totalmoney).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<insurance_policy>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("insurance_policy", "insurance");

                entity.Property(e => e.Reason).HasMaxLength(4000);

                entity.Property(e => e.Remedy_renew).HasMaxLength(4000);

                entity.Property(e => e.account_month)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.account_month_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.agent_commission_rate).HasColumnType("numeric(10, 6)");

                entity.Property(e => e.agent_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.approver_date).HasColumnType("datetime");

                entity.Property(e => e.approver_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.approver_status_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.bic_join_rate).HasColumnType("numeric(10, 6)");

                entity.Property(e => e.broker_commission_rate).HasColumnType("numeric(10, 6)");

                entity.Property(e => e.broker_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.business_type_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.cancel_status_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.changing_status_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.class_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.closed_date).HasColumnType("datetime");

                entity.Property(e => e.closed_staff_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.code_original)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.creator_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.currency_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.customer_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.deductible).HasMaxLength(4000);

                entity.Property(e => e.department_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.description_of_risk).HasMaxLength(4000);

                entity.Property(e => e.district_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.effectived_date).HasColumnType("datetime");

                entity.Property(e => e.handler_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.id_policy_ref).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.introducer).HasMaxLength(500);

                entity.Property(e => e.issue_date).HasColumnType("datetime");

                entity.Property(e => e.issue_form_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.list_of_coinsurer_share).HasMaxLength(500);

                entity.Property(e => e.location).HasMaxLength(4000);

                entity.Property(e => e.modifided_date).HasColumnType("datetime");

                entity.Property(e => e.note).HasMaxLength(500);

                entity.Property(e => e.package)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.pay_at_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.payer_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.policy_status_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.province_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.real_approver_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.reason_renew).HasMaxLength(4000);

                entity.Property(e => e.refused_reason).HasMaxLength(4000);

                entity.Property(e => e.reinsurance_date).HasColumnType("datetime");

                entity.Property(e => e.reinsurance_staff_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.reinsurance_status_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.reinsured_commission).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.reinsured_commission_rate).HasColumnType("numeric(10, 6)");

                entity.Property(e => e.reinsured_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.related_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.renew_date).HasColumnType("datetime");

                entity.Property(e => e.renew_policy_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.renew_policy_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.renew_status_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.renew_total_pre).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.renew_total_si).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.renew_underwriter_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.source_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.submit_date).HasColumnType("datetime");

                entity.Property(e => e.system_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.table_of_risk_catogories_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.total_accident_for_passenger_premium).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_bic_net_engineering_fee).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_bic_net_reinsurance_commission).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_bic_net_reinsurance_premium).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_bic_net_reinsurance_rate).HasColumnType("numeric(10, 6)");

                entity.Property(e => e.total_bic_net_reinsurance_si).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_claim_paid).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_coinsurance_leeding_fee)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.total_commission).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_commission_all).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_commission_tax).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_compulsory_liability_premium).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_fire_explosion_premium).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_pre_premium).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_pre_premium_all).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_premium).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_premium_all).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_premium_exchange).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_premium_other).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_premium_other_DPHCTT).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_premium_other_DPHCTT_all).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_premium_other_all).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_premium_other_cost).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_premium_other_cost_all).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_premium_paid).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_premium_vat).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_premium_vat_all).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_sum_insured).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_sum_insured_all).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_vat).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_vat_all).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_voluntary_for_damage_si).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_voluntary_liability_premium).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.underwriter_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.unit_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.valid_begin_date).HasColumnType("datetime");

                entity.Property(e => e.valid_end_date).HasColumnType("datetime");
            });

            modelBuilder.Entity<insurance_product>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("insurance_product", "list");

                entity.Property(e => e.agent_commision_tax_rate).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.agent_commission_rate).HasColumnType("numeric(10, 6)");

                entity.Property(e => e.agent_support_rate).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.broker_commission_rate).HasColumnType("numeric(10, 6)");

                entity.Property(e => e.code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.created_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.division_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.en_name).HasMaxLength(500);

                entity.Property(e => e.factor).HasColumnType("numeric(10, 5)");

                entity.Property(e => e.id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.insurance_product_group_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.insurance_product_group_level_one_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_date).HasColumnType("datetime");

                entity.Property(e => e.name).HasMaxLength(500);
            });

            modelBuilder.Entity<revenue_plan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("revenue_plan");

                entity.Property(e => e.branchid).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.code)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.fromdate).HasColumnType("datetime");

                entity.Property(e => e.id)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.name).HasMaxLength(500);

                entity.Property(e => e.productid).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.revenue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.todate).HasColumnType("datetime");

                entity.Property(e => e.type)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
