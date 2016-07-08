namespace NRPTmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_user
    {
        [Key]
        [StringLength(8)]
        public string user_id { get; set; }

        [Required]
        [StringLength(12)]
        public string user_first_nm { get; set; }

        [Required]
        [StringLength(17)]
        public string user_last_nm { get; set; }

        public DateTime user_last_updt_ts { get; set; }

        [Required]
        [StringLength(1)]
        public string user_actv_in { get; set; }

        [Required]
        [StringLength(50)]
        public string user_email_addr_nm { get; set; }

        [Required]
        [StringLength(1)]
        public string user_wkas_in { get; set; }

        public short user_max_sub_ct { get; set; }

        [Required]
        [StringLength(20)]
        public string user_ntwk_acct_nm { get; set; }

        [StringLength(5)]
        public string user_grade_lvl_cd { get; set; }

        [StringLength(10)]
        public string user_dept_id { get; set; }

        [StringLength(8)]
        public string user_supervisor_user_id { get; set; }

        [StringLength(11)]
        public string user_employee_id { get; set; }

        public DateTime user_ml_server_chg_ts { get; set; }

        [StringLength(2)]
        public string user_grade_step_cd { get; set; }

        [StringLength(5)]
        public string user_home_zip_code { get; set; }

        [StringLength(4)]
        public string user_occupation_cd { get; set; }
    }
}
