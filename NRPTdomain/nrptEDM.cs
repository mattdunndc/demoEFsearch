namespace NRPTmodel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class nrptEDM : DbContext
    {
        public nrptEDM()
            : base("name=nrptEDM")
        {
        }

        public virtual DbSet<t_dept_smart> t_dept_smart { get; set; }
        public virtual DbSet<t_inst_institutn> t_inst_institutn { get; set; }
        public virtual DbSet<t_rrac_activity> t_rrac_activity { get; set; }
        public virtual DbSet<t_rrqs_resource_request> t_rrqs_resource_request { get; set; }
        public virtual DbSet<t_user> t_user { get; set; }
        public virtual DbSet<v_rrqs_aggregated_requests> v_rrqs_aggregated_requests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<t_dept_smart>()
                .Property(e => e.dept_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_dept_smart>()
                .Property(e => e.dept_eff_stat_cd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_dept_smart>()
                .Property(e => e.dept_desc_tx)
                .IsUnicode(false);

            modelBuilder.Entity<t_dept_smart>()
                .Property(e => e.dept_abrv_nm)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_short_name)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_loc_city_name)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_loc_st_abbrv)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_loc_zip_code)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_loc_addr1)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_loc_addr2)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_full_name)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_actv_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_csrv_cd)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_mail_city_nm)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_mail_addr1)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_mail_addr2)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_mail_st_abbrv)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_mail_zip_code)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_supv_clas_cd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_occ_dllrs_am)
                .HasPrecision(12, 0);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_fdic_dllrs_am)
                .HasPrecision(12, 0);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_frb_dllrs_am)
                .HasPrecision(12, 0);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_canry_stat_cd)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_fdic_ins_cd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_supv_dept_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_geo_dept_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_adc_dept_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_loc_ctry_nm)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_regulator_cd)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_sarbanes_oxley_req_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_sarbanes_oxley_cmplnt_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_tfag_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_ocws_worksite_cd)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_ots_dllrs_am)
                .HasPrecision(12, 0);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_ots_docket_nr)
                .HasPrecision(9, 0);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_ots_owner_nr)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_thrift_stock_mutual_tx)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_latest_asset_am)
                .HasPrecision(15, 2);

            modelBuilder.Entity<t_inst_institutn>()
                .Property(e => e.inst_abbrv_nm)
                .IsUnicode(false);

            modelBuilder.Entity<t_inst_institutn>()
                .HasMany(e => e.t_rrac_activity)
                .WithOptional(e => e.t_inst_institutn)
                .HasForeignKey(e => e.rrac_inst_id);

            modelBuilder.Entity<t_inst_institutn>()
                .HasMany(e => e.t_rrqs_resource_request)
                .WithOptional(e => e.t_inst_institutn)
                .HasForeignKey(e => e.rrqs_inst_id);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_id)
                .HasPrecision(6, 0);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_funct_area_rrfa_cd)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_work_loc_city_nm)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_work_loc_state_cd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_eic_priority_cd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_contact_user_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_comment_tx)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_create_user_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_last_appupdt_user_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_primary_rrac_id)
                .HasPrecision(6, 0);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_primary_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_developmental_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_work_loc_country_nm)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_delete_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_activity_type_cd)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_team_lead_user_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_namlg_nomination_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_namlg_nomination_tx)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_nti_nomination_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_nti_nomination_tx)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_priority_reason_cd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrac_activity>()
                .Property(e => e.rrac_lbs_priority_cd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrac_activity>()
                .HasMany(e => e.t_rrac_activity1)
                .WithOptional(e => e.t_rrac_activity2)
                .HasForeignKey(e => e.rrac_primary_rrac_id);

            modelBuilder.Entity<t_rrac_activity>()
                .HasMany(e => e.t_rrqs_resource_request)
                .WithRequired(e => e.t_rrac_activity)
                .HasForeignKey(e => e.rrqs_activity_rrac_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_job_id)
                .HasPrecision(6, 0);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_activity_rrac_id)
                .HasPrecision(6, 0);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_assignment_desc_tx)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_devl_prod_cd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_qtr_date_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_req_exmr_user_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_req_dept_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_req_grade_lvl_cd)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_req_contract_exmr_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_req_alt_agency_cd)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_req_comment_tx)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_status_cd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_actual_exmr_user_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_actual_grade_lvl_cd)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_actual_dept_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_actual_contract_exmr_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_actual_alt_agency_cd)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_actual_comment_tx)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_create_user_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_role_type_cd)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_last_appupdt_user_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_complexity_cd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_functional_eic_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_interface_direction_cd)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_sub_funct_rras_id)
                .HasPrecision(6, 0);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_work_loc_city_nm)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_work_loc_state_cd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_work_loc_country_nm)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_eic_priority_cd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_delete_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_defer_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_rrcd_id)
                .HasPrecision(6, 0);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_oaex_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_confirm_user_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrqs_resource_request>()
                .Property(e => e.rrqs_work_days_type_cd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_first_nm)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_last_nm)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_actv_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_email_addr_nm)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_wkas_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_ntwk_acct_nm)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_grade_lvl_cd)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_dept_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_supervisor_user_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_employee_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_grade_step_cd)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_home_zip_code)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_occupation_cd)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .HasMany(e => e.t_rrac_activity)
                .WithRequired(e => e.t_user)
                .HasForeignKey(e => e.rrac_last_appupdt_user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_user>()
                .HasMany(e => e.t_rrac_activity1)
                .WithRequired(e => e.t_user1)
                .HasForeignKey(e => e.rrac_contact_user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_user>()
                .HasMany(e => e.t_rrac_activity2)
                .WithRequired(e => e.t_user2)
                .HasForeignKey(e => e.rrac_create_user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_user>()
                .HasMany(e => e.t_rrac_activity3)
                .WithOptional(e => e.t_user3)
                .HasForeignKey(e => e.rrac_team_lead_user_id);

            modelBuilder.Entity<t_user>()
                .HasMany(e => e.t_rrqs_resource_request)
                .WithOptional(e => e.t_user)
                .HasForeignKey(e => e.rrqs_actual_exmr_user_id);

            modelBuilder.Entity<t_user>()
                .HasMany(e => e.t_rrqs_resource_request1)
                .WithOptional(e => e.t_user1)
                .HasForeignKey(e => e.rrqs_confirm_user_id);

            modelBuilder.Entity<t_user>()
                .HasMany(e => e.t_rrqs_resource_request2)
                .WithRequired(e => e.t_user2)
                .HasForeignKey(e => e.rrqs_create_user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_user>()
                .HasMany(e => e.t_rrqs_resource_request3)
                .WithRequired(e => e.t_user3)
                .HasForeignKey(e => e.rrqs_last_appupdt_user_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_user>()
                .HasMany(e => e.t_rrqs_resource_request4)
                .WithOptional(e => e.t_user4)
                .HasForeignKey(e => e.rrqs_req_exmr_user_id);

            modelBuilder.Entity<v_rrqs_aggregated_requests>()
                .Property(e => e.activity_id)
                .HasPrecision(6, 0);

            modelBuilder.Entity<v_rrqs_aggregated_requests>()
                .Property(e => e.activity_status)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<NRPTmodel.t_proj_project> t_proj_project { get; set; }
    }
}
