namespace NRPTmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_proj_projectDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int proj_id { get; set; }

        [StringLength(80)]
        public string proj_project_nm { get; set; }

        public string proj_project_desc_tx { get; set; }

        [StringLength(4)]
        public string pobj_project_type_cd { get; set; }

        public string project_type_desc { get; set; } //added mjd

        [Column(TypeName = "date")]
        public DateTime? proj_start_dt { get; set; }

        [Column(TypeName = "date")]
        public DateTime? proj_end_dt { get; set; }

        [Required]
        [StringLength(8)]
        public string proj_contact_user_id { get; set; }

        [Required]
        [StringLength(1)]
        public string proj_active_in { get; set; }

        [Required]
        [StringLength(8)]
        public string proj_last_updt_user_id { get; set; }

        public DateTime proj_last_updt_ts { get; set; }

        public int apps { get; set; }
        public int institutions { get; set; }
        public int depts { get; set; }

        public string contact { get; set; }

        
    }
}
