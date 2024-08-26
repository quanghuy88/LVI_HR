using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
        //public virtual DbSet<chart_general_result> chart_general_results { get; set; } = null!;
        //public virtual DbSet<chart_premium_revenue> chart_premium_revenues { get; set; } = null!;
        public virtual DbSet<dwh_acc_account> dwh_acc_accounts { get; set; } = null!;
        public virtual DbSet<dwh_acc_active_account_month> dwh_acc_active_account_months { get; set; } = null!;
        public virtual DbSet<dwh_acc_auto_posting> dwh_acc_auto_postings { get; set; } = null!;
        public virtual DbSet<dwh_acc_claim> dwh_acc_claims { get; set; } = null!;
        public virtual DbSet<dwh_acc_claim_payment> dwh_acc_claim_payments { get; set; } = null!;
        public virtual DbSet<dwh_acc_claim_payment_detail> dwh_acc_claim_payment_details { get; set; } = null!;
        public virtual DbSet<dwh_acc_claim_proccess_status> dwh_acc_claim_proccess_statuses { get; set; } = null!;
        public virtual DbSet<dwh_acc_claim_process> dwh_acc_claim_processes { get; set; } = null!;
        public virtual DbSet<dwh_acc_claim_process_detail> dwh_acc_claim_process_details { get; set; } = null!;
        public virtual DbSet<dwh_acc_code_order> dwh_acc_code_orders { get; set; } = null!;
        public virtual DbSet<dwh_acc_major_group> dwh_acc_major_groups { get; set; } = null!;
        public virtual DbSet<dwh_acc_policy> dwh_acc_policies { get; set; } = null!;
        public virtual DbSet<dwh_acc_policy_instalment> dwh_acc_policy_instalments { get; set; } = null!;
        public virtual DbSet<dwh_acc_unearned_listing> dwh_acc_unearned_listings { get; set; } = null!;
        public virtual DbSet<dwh_acc_unearned_of_month> dwh_acc_unearned_of_months { get; set; } = null!;
        public virtual DbSet<dwh_acc_voucher> dwh_acc_vouchers { get; set; } = null!;
        public virtual DbSet<dwh_acc_voucher_claim_detail> dwh_acc_voucher_claim_details { get; set; } = null!;
        public virtual DbSet<dwh_acc_voucher_status> dwh_acc_voucher_statuses { get; set; } = null!;
        public virtual DbSet<dwh_admin_user> dwh_admin_users { get; set; } = null!;
        public virtual DbSet<dwh_cfig_report_month> dwh_cfig_report_months { get; set; } = null!;
        public virtual DbSet<dwh_fact_branch_cg_date> dwh_fact_branch_cg_dates { get; set; } = null!;
        public virtual DbSet<dwh_fact_branch_cg_month> dwh_fact_branch_cg_months { get; set; } = null!;
        public virtual DbSet<dwh_fact_branch_class_date> dwh_fact_branch_class_dates { get; set; } = null!;
        public virtual DbSet<dwh_fact_branch_class_month> dwh_fact_branch_class_months { get; set; } = null!;
        public virtual DbSet<dwh_fact_document> dwh_fact_documents { get; set; } = null!;
        public virtual DbSet<dwh_list_auto_posting_code> dwh_list_auto_posting_codes { get; set; } = null!;
        public virtual DbSet<dwh_list_branch> dwh_list_branches { get; set; } = null!;
        public virtual DbSet<dwh_list_insurance_product> dwh_list_insurance_products { get; set; } = null!;
        public virtual DbSet<dwh_revenue_month_branch> dwh_revenue_month_branches { get; set; } = null!;
        public virtual DbSet<dwh_revenue_month_branch> dwh_revenue_target { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<chart_general_result>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("chart_general_result");

            //    entity.Property(e => e.cvalue).HasColumnType("numeric(18, 2)");

            //    entity.Property(e => e.datadate).HasColumnType("datetime");

            //    entity.Property(e => e.desc).HasMaxLength(250);

            //    entity.Property(e => e.evalue).HasColumnType("numeric(18, 2)");

            //    entity.Property(e => e.id).ValueGeneratedOnAdd();

            //    entity.Property(e => e.name).HasMaxLength(250);

            //    entity.Property(e => e.pkvalue).HasColumnType("numeric(18, 2)");

            //    entity.Property(e => e.pvalue).HasColumnType("numeric(18, 2)");

            //    entity.Property(e => e.tvalue).HasColumnType("numeric(18, 2)");
            //});

            //modelBuilder.Entity<chart_premium_revenue>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("chart_premium_revenue");

            //    entity.Property(e => e.category).HasMaxLength(250);

            //    entity.Property(e => e.datadate).HasColumnType("datetime");

            //    entity.Property(e => e.description).HasMaxLength(250);

            //    entity.Property(e => e.premium).HasColumnType("numeric(18, 2)");
            //});

            modelBuilder.Entity<dwh_acc_account>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_acc_account");

                entity.Property(e => e.account_property_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.account_type_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.code_bs)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.code_lao)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.code_pl)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.code_pl2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.code_ref)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.created_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.currency_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_date).HasColumnType("datetime");

                entity.Property(e => e.name).HasMaxLength(500);

                entity.Property(e => e.name_en).HasMaxLength(500);

                entity.Property(e => e.name_lao).HasMaxLength(500);

                entity.Property(e => e.name_other).HasMaxLength(500);

                entity.Property(e => e.note).HasMaxLength(4000);

                entity.Property(e => e.parent_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.rate_type_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.unit_id).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<dwh_acc_active_account_month>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_acc_active_account_month");

                entity.Property(e => e.account_month_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.active_date).HasColumnType("datetime");

                entity.Property(e => e.created_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.finish_date).HasColumnType("datetime");

                entity.Property(e => e.modified_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_date).HasColumnType("datetime");

                entity.Property(e => e.next_month_id).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<dwh_acc_auto_posting>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_acc_auto_posting");

                entity.Property(e => e.account_credit_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.account_credit_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.account_debit_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.account_debit_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.account_policy_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.account_policy_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.code_order_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_date).HasColumnType("datetime");

                entity.Property(e => e.name).HasMaxLength(500);

                entity.Property(e => e.name_other).HasMaxLength(500);

                entity.Property(e => e.note).HasMaxLength(4000);

                entity.Property(e => e.operation_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.type)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<dwh_acc_claim>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_acc_claim");

                entity.Property(e => e.application_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.application_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.class_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.class_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.created_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.currency_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.currency_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.customer_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.customer_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.department_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.from_date).HasColumnType("datetime");

                entity.Property(e => e.id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.id_ref).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.loss_date).HasColumnType("datetime");

                entity.Property(e => e.modified_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_date).HasColumnType("datetime");

                entity.Property(e => e.policy_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.policy_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.policy_system_type_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.report_date).HasColumnType("datetime");

                entity.Property(e => e.to_date).HasColumnType("datetime");

                entity.Property(e => e.underwriting_form_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.underwriting_form_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.unit_id).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<dwh_acc_claim_payment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_acc_claim_payment");

                entity.Property(e => e.account_month).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.account_payment_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.accountant_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.balance_money).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.balance_money_exchange).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.claim_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.claim_proccess_detail_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.claim_proccess_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.currency_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.currency_rate).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.domain_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.instalment_month).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.instalment_number).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.payment_money).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.payment_money_exchange).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.policy_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.premium_money).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_payment_money).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_payment_money_exchange).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.vat_money).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.voucher_id).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<dwh_acc_claim_payment_detail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_acc_claim_payment_detail");

                entity.Property(e => e.claim_payment_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.paid_money_amount).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.paid_money_amount_exchange).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.voucher_id).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<dwh_acc_claim_proccess_status>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_acc_claim_proccess_status");

                entity.Property(e => e.code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.created_bye).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_date).HasColumnType("datetime");

                entity.Property(e => e.name).HasMaxLength(500);
            });

            modelBuilder.Entity<dwh_acc_claim_process>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_acc_claim_process");

                entity.Property(e => e.account_month_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.claim_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.claim_process_status_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.claim_process_type_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.date_of_payment).HasColumnType("datetime");

                entity.Property(e => e.id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.id_ref).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.id_ref_biccare).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.money_of_payment).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.voucher_id).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<dwh_acc_claim_process_detail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_acc_claim_process_detail");

                entity.Property(e => e.account_month_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.amount_money).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.auto_posting_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.auto_posting_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.claim_proccess_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.contract_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.contract_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.description).HasMaxLength(4000);

                entity.Property(e => e.domain_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.domain_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.reinsurance_rate).HasColumnType("numeric(5, 2)");
            });

            modelBuilder.Entity<dwh_acc_code_order>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_acc_code_order");

                entity.Property(e => e.code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.created_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_date).HasColumnType("datetime");

                entity.Property(e => e.name).HasMaxLength(500);
            });

            modelBuilder.Entity<dwh_acc_major_group>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_acc_major_group");

                entity.Property(e => e.code)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ename)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.id).ValueGeneratedOnAdd();

                entity.Property(e => e.name).HasMaxLength(2000);

                entity.Property(e => e.represent_class_code)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.sub_class_code)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.sub_ename)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.sub_name).HasMaxLength(2000);
            });

            modelBuilder.Entity<dwh_acc_policy>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_acc_policy");

                entity.Property(e => e.agent_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.agent_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.application_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.application_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.broker_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.broker_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.class_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.closed_date).HasColumnType("datetime");

                entity.Property(e => e.code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.commission_rate).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.created_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.currency_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.currency_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.customer_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.customer_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.department_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.form_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.form_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.from_date).HasColumnType("datetime");

                entity.Property(e => e.id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.id_ref).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_date).HasColumnType("datetime");

                entity.Property(e => e.payer_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.payer_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.policy_system_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.policy_system_type_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.risk_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.source_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.source_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.sum_insured).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.to_date).HasColumnType("datetime");

                entity.Property(e => e.total_commission_money).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_money).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_premium_money).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_vat_money).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.underwriter_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.underwriting_form_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.underwriting_month)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.unit_id).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<dwh_acc_policy_instalment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_acc_policy_instalment");

                entity.Property(e => e.commission_money).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.date_of_payment_commission).HasColumnType("datetime");

                entity.Property(e => e.date_of_payment_premium).HasColumnType("datetime");

                entity.Property(e => e.id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.instalment_id_biccare_ref).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.instalment_month_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.instalment_number).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.invoice_date).HasColumnType("datetime");

                entity.Property(e => e.invoice_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.invoice_no)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.money_of_payment_commission).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.money_of_payment_premium).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.month_of_revenue_recognition).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.old_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.period_paid).HasColumnType("datetime");

                entity.Property(e => e.policy_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.premium_management_fee).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.premium_money).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.real_rate).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.retention_rate).HasColumnType("numeric(10, 6)");

                entity.Property(e => e.serial_no)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.status_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.vat_money).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.voucher_id).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<dwh_acc_unearned_listing>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_acc_unearned_listing");

                entity.Property(e => e._class)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("class");

                entity.Property(e => e.account_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.account_month).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.currency_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.currency_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.currency_rate).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.domain_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.exchange_money).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.foreign_money).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.from_date).HasColumnType("datetime");

                entity.Property(e => e.id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.instalment_month).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.is_deleted).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.policy_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.policy_instalment_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.to_date).HasColumnType("datetime");

                entity.Property(e => e.transaction_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.underwriting_form_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.unit_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.voucher_id).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<dwh_acc_unearned_of_month>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_acc_unearned_of_month");

                entity.Property(e => e.account_month_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.credit_account_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.debit_account_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.exchange_earned).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.exchange_unearned).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.foreign_earned).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.foreign_unearned).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.from_date).HasColumnType("datetime");

                entity.Property(e => e.id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.to_date).HasColumnType("datetime");

                entity.Property(e => e.transaction_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.type)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.underwriting_form_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.unearned_listing_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.voucher_id).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<dwh_acc_voucher>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_acc_voucher");

                entity.Property(e => e.account_month_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.account_rate).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.approve_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.approve_date).HasColumnType("datetime");

                entity.Property(e => e.content).HasMaxLength(4000);

                entity.Property(e => e.created_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.currency_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.date).HasColumnType("datetime");

                entity.Property(e => e.document_date).HasColumnType("datetime");

                entity.Property(e => e.document_number)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_date).HasColumnType("datetime");

                entity.Property(e => e.object_address).HasMaxLength(500);

                entity.Property(e => e.object_unit).HasMaxLength(500);

                entity.Property(e => e.operation_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.post_date).HasColumnType("datetime");

                entity.Property(e => e.post_number)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.real_rate).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.reason).HasMaxLength(4000);

                entity.Property(e => e.ref_number)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.total_foreign_money).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.total_original_money).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.unit_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.voucher_old_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.voucher_status_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.voucher_type_id).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<dwh_acc_voucher_claim_detail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_acc_voucher_claim_detail");

                entity.Property(e => e.credit_account_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.credit_claim_code).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.credit_claim_proccess_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.credit_class_code).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.credit_dept_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.credit_domain_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.credit_policy_code).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.credit_policy_instalment_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.credit_resource_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.currency_code).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.currency_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.currency_rate).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.datadate).HasColumnType("datetime");

                entity.Property(e => e.debit_account_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.debit_claim_code).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.debit_claim_proccess_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.debit_class_code).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.debit_dept_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.debit_domain_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.debit_policy_code).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.debit_policy_instalment_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.debit_resource_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.description).HasMaxLength(4000);

                entity.Property(e => e.foreign_money).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.id).HasMaxLength(4000);

                entity.Property(e => e.original_money).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.unequal_money).HasColumnType("numeric(30, 2)");

                entity.Property(e => e.voucher_detail_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.voucher_id).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<dwh_acc_voucher_status>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_acc_voucher_status");

                entity.Property(e => e.code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.created_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_date).HasColumnType("datetime");

                entity.Property(e => e.name).HasMaxLength(500);

                entity.Property(e => e.note).HasMaxLength(4000);
            });

            modelBuilder.Entity<dwh_admin_user>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_admin_user");

                entity.Property(e => e.branch_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_date).HasColumnType("datetime");

                entity.Property(e => e.name).HasMaxLength(500);

                entity.Property(e => e.name_en).HasMaxLength(500);

                entity.Property(e => e.note).HasMaxLength(4000);

                entity.Property(e => e.original_user_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.password).HasMaxLength(4000);

                entity.Property(e => e.password_decrypted).HasMaxLength(4000);

                entity.Property(e => e.staff_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.unit_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.username)
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<dwh_cfig_report_month>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_cfig_report_month");

                entity.Property(e => e.closedmonths).HasMaxLength(250);

                entity.Property(e => e.id).ValueGeneratedOnAdd();

                entity.Property(e => e.remark).HasMaxLength(500);

                entity.Property(e => e.reportmonths).HasMaxLength(250);
            });

            modelBuilder.Entity<dwh_fact_branch_cg_date>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_fact_branch_cg_date");

                entity.Property(e => e.account_year).HasColumnType("numeric(18, 0)");
                entity.Property(e => e.account_month).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.branch_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.datadate).HasColumnType("datetime");
                entity.Property(e => e.int_datadate).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.original_money).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.foreign_money).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.class_group_id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<dwh_fact_branch_cg_month>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_fact_branch_cg_month");

                entity.Property(e => e.branch_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.datadate).HasColumnType("datetime");
                entity.Property(e => e.int_datadate).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.exchange_non_retention_compensation_money).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.exchange_revenue_money).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.exchange_total_compensation_money).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.foreign_non_retention_compensation_money).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.foreign_revenue_money).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.foreign_total_compensation_money).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.class_group_code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<dwh_fact_branch_class_date>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_fact_branch_class_date");

                entity.Property(e => e.account_year)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.branch_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.class_code).HasMaxLength(50);

                entity.Property(e => e.class_group_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.account_month).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.original_money).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.foreign_money).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.code_order).HasMaxLength(50);

                entity.Property(e => e.datadate).HasColumnType("datetime");

                entity.Property(e => e.int_datadate).HasColumnType("numeric(18, 0)");


                entity.Property(e => e.id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<dwh_fact_branch_class_month>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_fact_branch_class_month");

                entity.Property(e => e.account_year)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.branch_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.class_code).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.datadate).HasColumnType("datetime");

                entity.Property(e => e.exchange_revenue_money).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.foreign_revenue_money).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<dwh_fact_document>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_fact_document");

                entity.Property(e => e.account_year)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.class_code).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.co_code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.credit_account_id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.datadate).HasColumnType("datetime");

                entity.Property(e => e.debit_account_id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.exchange_money).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.foreign_money).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.unit_id).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<dwh_list_auto_posting_code>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_list_auto_posting_code");

                entity.Property(e => e.code)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.created_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.created_date).HasColumnType("datetime");

                entity.Property(e => e.modified_by).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.modified_date).HasColumnType("datetime");

                entity.Property(e => e.name).HasMaxLength(500);

                entity.Property(e => e.note).HasMaxLength(4000);

                entity.Property(e => e.string_check_sql).HasMaxLength(4000);

                entity.Property(e => e.string_insert_sql).HasMaxLength(4000);

                entity.Property(e => e.system_code)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<dwh_list_branch>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_list_branch");

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

            modelBuilder.Entity<dwh_list_insurance_product>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_list_insurance_product");

                entity.Property(e => e.agent_commision_tax_rate).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.agent_commission_rate).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.agent_support_rate).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.broker_commission_rate).HasColumnType("numeric(5, 2)");

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

            modelBuilder.Entity<dwh_revenue_month_branch>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_revenue_month_branch");

                entity.Property(e => e.account_year)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.branch_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.exchange_compensation_money).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.exchange_profit_money).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.exchange_revenue_money).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.foreign_compensation_money).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.foreign_profit_money).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.foreign_revenue_money).HasColumnType("numeric(18, 2)");

                entity.Property(e => e.id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<dwh_revenue_profit_target>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dwh_revenue_profit_target");

                entity.Property(e => e.target).HasColumnType("numeric(18, 0)");
                entity.Property(e => e.target_name).HasMaxLength(50);

                entity.Property(e => e.branch_id).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.account_month).HasMaxLength(50);

                entity.Property(e => e.account_year).HasMaxLength(50);

                entity.Property(e => e.id)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
