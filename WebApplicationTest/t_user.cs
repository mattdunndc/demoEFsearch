//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationTest
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_user
    {
        public string user_id { get; set; }
        public string user_first_nm { get; set; }
        public string user_last_nm { get; set; }
        public System.DateTime user_last_updt_ts { get; set; }
        public string user_actv_in { get; set; }
        public string user_email_addr_nm { get; set; }
        public string user_wkas_in { get; set; }
        public short user_max_sub_ct { get; set; }
        public string user_ntwk_acct_nm { get; set; }
        public string user_grade_lvl_cd { get; set; }
        public string user_dept_id { get; set; }
        public string user_supervisor_user_id { get; set; }
        public string user_employee_id { get; set; }
        public System.DateTime user_ml_server_chg_ts { get; set; }
        public string user_grade_step_cd { get; set; }
        public string user_home_zip_code { get; set; }
        public string user_occupation_cd { get; set; }
        public string t_dept_smart_dept_id { get; set; }
    
        public virtual t_dept_smart t_dept_smart { get; set; }
    }
}