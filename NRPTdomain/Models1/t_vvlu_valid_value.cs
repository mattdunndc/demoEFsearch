namespace NRPTmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_vvlu_valid_value
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int vvlu_id { get; set; }

        [Required]
        [StringLength(30)]
        public string vvlu_col_nm { get; set; }

        public int? vvlu_num_vlu_cd { get; set; }

        [StringLength(240)]
        public string vvlu_char_vlu_cd { get; set; }

        public DateTime? vvlu_eff_dt { get; set; }

        public DateTime? vvlu_exp_dt { get; set; }

        [StringLength(240)]
        public string vvlu_desc_tx { get; set; }

        public short? vvlu_disp_seq_nr { get; set; }

        [Required]
        [StringLength(1)]
        public string vvlu_envr_spcfc_in { get; set; }

        public DateTime vvlu_ml_server_chg_ts { get; set; }
    }
}
