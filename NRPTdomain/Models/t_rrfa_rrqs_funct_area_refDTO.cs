using System.Runtime.Serialization;

namespace NRPTmodel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [DataContract]
    public partial class t_rrfa_rrqs_funct_area_refDTO
    {
        [DataMember] // include with serialization xml/json
        [Key]
        [StringLength(4)]
        public string rrfa_cd { get; set; }
        [DataMember] // include with serialization xml/json
        [Required]
        [StringLength(40)]
        public string rrfa_function_area_tx { get; set; }
    }
}
