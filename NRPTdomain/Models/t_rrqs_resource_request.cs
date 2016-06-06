namespace NRPTmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rrqs_resource_request
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal rrqs_job_id { get; set; }

        public int? rrqs_inst_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal rrqs_activity_rrac_id { get; set; }

        [StringLength(120)]
        public string rrqs_assignment_desc_tx { get; set; }

        [Required]
        [StringLength(1)]
        public string rrqs_devl_prod_cd { get; set; }

        [Required]
        [StringLength(1)]
        public string rrqs_qtr_date_in { get; set; }

        public DateTime rrqs_start_dt { get; set; }

        public DateTime rrqs_end_dt { get; set; }

        public int rrqs_work_days_ct { get; set; }

        [StringLength(8)]
        public string rrqs_req_exmr_user_id { get; set; }

        [StringLength(10)]
        public string rrqs_req_dept_id { get; set; }

        [StringLength(5)]
        public string rrqs_req_grade_lvl_cd { get; set; }

        [Required]
        [StringLength(1)]
        public string rrqs_req_contract_exmr_in { get; set; }

        [StringLength(4)]
        public string rrqs_req_alt_agency_cd { get; set; }

        [StringLength(120)]
        public string rrqs_req_comment_tx { get; set; }

        [Required]
        [StringLength(1)]
        public string rrqs_status_cd { get; set; }

        [StringLength(8)]
        public string rrqs_actual_exmr_user_id { get; set; }

        [StringLength(5)]
        public string rrqs_actual_grade_lvl_cd { get; set; }

        [StringLength(10)]
        public string rrqs_actual_dept_id { get; set; }

        [StringLength(1)]
        public string rrqs_actual_contract_exmr_in { get; set; }

        [StringLength(4)]
        public string rrqs_actual_alt_agency_cd { get; set; }

        [StringLength(120)]
        public string rrqs_actual_comment_tx { get; set; }

        [Required]
        [StringLength(8)]
        public string rrqs_create_user_id { get; set; }

        [StringLength(6)]
        public string rrqs_role_type_cd { get; set; }

        public DateTime rrqs_create_ts { get; set; }

        [Required]
        [StringLength(8)]
        public string rrqs_last_appupdt_user_id { get; set; }

        public DateTime rrqs_last_updt_ts { get; set; }

        [StringLength(1)]
        public string rrqs_complexity_cd { get; set; }

        [Required]
        [StringLength(1)]
        public string rrqs_functional_eic_in { get; set; }

        [StringLength(10)]
        public string rrqs_interface_direction_cd { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? rrqs_sub_funct_rras_id { get; set; }

        public int? rrqs_work_loc_rrlc_id { get; set; }

        [StringLength(28)]
        public string rrqs_work_loc_city_nm { get; set; }

        [StringLength(2)]
        public string rrqs_work_loc_state_cd { get; set; }

        [StringLength(80)]
        public string rrqs_work_loc_country_nm { get; set; }

        [StringLength(1)]
        public string rrqs_eic_priority_cd { get; set; }

        [Required]
        [StringLength(1)]
        public string rrqs_delete_in { get; set; }

        [Required]
        [StringLength(1)]
        public string rrqs_defer_in { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? rrqs_rrcd_id { get; set; }

        [StringLength(8)]
        public string rrqs_oaex_id { get; set; }

        [StringLength(8)]
        public string rrqs_confirm_user_id { get; set; }

        public DateTime rrqs_ml_server_chg_ts { get; set; }

        [Column(TypeName = "date")]
        public DateTime? rrqs_confirm_dt { get; set; }

        [StringLength(1)]
        public string rrqs_work_days_type_cd { get; set; }

        public virtual t_inst_institutn t_inst_institutn { get; set; }

        public virtual t_rrac_activity t_rrac_activity { get; set; }

        public virtual t_user t_user { get; set; }

        public virtual t_user t_user1 { get; set; }

        public virtual t_user t_user2 { get; set; }

        public virtual t_user t_user3 { get; set; }

        public virtual t_user t_user4 { get; set; }
    }
}
