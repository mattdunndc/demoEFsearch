namespace NRPTmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_usaa_app_access
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string usaa_user_id { get; set; }

        [Required]
        [StringLength(1)]
        public string usaa_app_active_in { get; set; }

        [Column(TypeName = "text")]
        public string usaa_preference_tx { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int usaa_scad_id { get; set; }

        public DateTime usaa_ml_server_chg_ts { get; set; }

        public int? usaa_notify_event_freq_id { get; set; }

        public virtual t_user t_user { get; set; }
    }
}
