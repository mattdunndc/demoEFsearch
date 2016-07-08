namespace NRPTmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_prap_proj_scadDTO
    {
        [Key]
        public int prap_proj_id { get; set; }

        [Key]
        public int prap_scad_id { get; set; }

        [StringLength(40)]
        public string scad_app_nm { get; set; }
    }
}
