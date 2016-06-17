using System.ComponentModel;
using System.Runtime.Serialization;

namespace NRPTmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [DataContract]
    public partial class t_userDTOmin
    {
        [DataMember] // include with serialization xml/json
        [Key]
        [StringLength(8)]
        public string user_id { get; set; }

        [DataMember]
        [StringLength(20)]
        public string fullName { get; set; }

    }
}
