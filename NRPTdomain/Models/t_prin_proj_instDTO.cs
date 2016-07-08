namespace NRPTmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_prin_proj_instDTO
    {
        [Key]
        public int prin_proj_id { get; set; }

        public int prin_inst_id { get; set; }

        public int inst_occ_asgnd_id { get; set; }

        [StringLength(40)]
        public string inst_short_name { get; set; }
        
    }
}
