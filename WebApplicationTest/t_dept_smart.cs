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
    
    public partial class t_dept_smart
    {
        public t_dept_smart()
        {
            this.t_user = new HashSet<t_user>();
        }
    
        public string dept_id { get; set; }
        public string dept_eff_stat_cd { get; set; }
        public string dept_desc_tx { get; set; }
        public Nullable<int> dept_budg_cd { get; set; }
        public string dept_abrv_nm { get; set; }
        public System.DateTime dept_ml_server_chg_ts { get; set; }
    
        public virtual ICollection<t_user> t_user { get; set; }
    }
}
