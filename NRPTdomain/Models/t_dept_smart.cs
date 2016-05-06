namespace NRPTmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_dept_smart
    {
        [Key]
        [StringLength(10)]
        public string dept_id { get; set; }

        [Required]
        [StringLength(1)]
        public string dept_eff_stat_cd { get; set; }

        [Required]
        [StringLength(40)]
        public string dept_desc_tx { get; set; }

        public int? dept_budg_cd { get; set; }

        [StringLength(20)]
        public string dept_abrv_nm { get; set; }

        public DateTime dept_ml_server_chg_ts { get; set; }
    }
}
