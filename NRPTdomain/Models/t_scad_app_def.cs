namespace NRPTmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    
    [DataContract]
    public partial class t_scad_app_def
    {
        public t_scad_app_def()
        {
            t_prap_proj_scad = new HashSet<t_prap_proj_scad>();
        }

        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int scad_id { get; set; }

        [DataMember]
        [Required]
        [StringLength(40)]
        public string scad_app_nm { get; set; }

        [Required]
        [StringLength(100)]
        public string scad_description_tx { get; set; }

        [DataMember]
        [StringLength(1)]
        public string scad_district_access_in { get; set; }

        public DateTime scad_ml_server_chg_ts { get; set; }
        
        public virtual ICollection<t_prap_proj_scad> t_prap_proj_scad { get; set; }

    }
}
