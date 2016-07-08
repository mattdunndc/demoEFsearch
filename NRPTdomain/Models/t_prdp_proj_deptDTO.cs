namespace NRPTmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_prdp_proj_deptDTO
    {
        [Key]
        public int prdp_proj_id { get; set; }

        [Key]
        [StringLength(10)]
        public string prdp_dept_id { get; set; }

        public int? dept_budg_cd { get; set; }

        [StringLength(20)]
        public string dept_abrv_nm { get; set; }

    }
}
