namespace NRPTmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_rrac_activity
    {
        public t_rrac_activity()
        {
            t_rrac_activity1 = new HashSet<t_rrac_activity>();
            t_rrqs_resource_request = new HashSet<t_rrqs_resource_request>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal rrac_id { get; set; }

        public int? rrac_inst_id { get; set; }

        public int? rrac_work_loc_rrlc_id { get; set; }

        [StringLength(4)]
        public string rrac_funct_area_rrfa_cd { get; set; }

        [StringLength(28)]
        public string rrac_work_loc_city_nm { get; set; }

        [StringLength(2)]
        public string rrac_work_loc_state_cd { get; set; }

        [StringLength(1)]
        public string rrac_eic_priority_cd { get; set; }

        [Required]
        [StringLength(8)]
        public string rrac_contact_user_id { get; set; }

        [StringLength(120)]
        public string rrac_comment_tx { get; set; }

        public DateTime rrac_create_ts { get; set; }

        [Required]
        [StringLength(8)]
        public string rrac_create_user_id { get; set; }

        public DateTime rrac_last_updt_ts { get; set; }

        [Required]
        [StringLength(8)]
        public string rrac_last_appupdt_user_id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? rrac_primary_rrac_id { get; set; }

        [Required]
        [StringLength(1)]
        public string rrac_primary_in { get; set; }

        [StringLength(1)]
        public string rrac_developmental_in { get; set; }

        [StringLength(80)]
        public string rrac_work_loc_country_nm { get; set; }

        [Required]
        [StringLength(1)]
        public string rrac_delete_in { get; set; }

        public DateTime rrac_quarter_end_dt { get; set; }

        [StringLength(12)]
        public string rrac_activity_type_cd { get; set; }

        [StringLength(8)]
        public string rrac_team_lead_user_id { get; set; }

        [Required]
        [StringLength(1)]
        public string rrac_namlg_nomination_in { get; set; }

        [StringLength(120)]
        public string rrac_namlg_nomination_tx { get; set; }

        [Required]
        [StringLength(1)]
        public string rrac_nti_nomination_in { get; set; }

        [StringLength(120)]
        public string rrac_nti_nomination_tx { get; set; }

        public DateTime rrac_ml_server_chg_ts { get; set; }

        [StringLength(1)]
        public string rrac_priority_reason_cd { get; set; }

        [StringLength(1)]
        public string rrac_lbs_priority_cd { get; set; }

        public int? rrac_proj_id { get; set; }

        public virtual t_inst_institutn t_inst_institutn { get; set; }

        public virtual ICollection<t_rrac_activity> t_rrac_activity1 { get; set; }

        public virtual t_rrac_activity t_rrac_activity2 { get; set; }

        public virtual ICollection<t_rrqs_resource_request> t_rrqs_resource_request { get; set; }

        public virtual t_user t_user { get; set; }

        public virtual t_user t_user1 { get; set; }

        public virtual t_user t_user2 { get; set; }

        public virtual t_user t_user3 { get; set; }
    }
}
