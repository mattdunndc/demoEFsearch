namespace NRPTmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_vvlu_valid_valueDTO
    {
        [StringLength(240)]
        public string vvlu_char_vlu_cd { get; set; }

        [StringLength(240)]
        public string vvlu_desc_tx { get; set; }
    }
}
