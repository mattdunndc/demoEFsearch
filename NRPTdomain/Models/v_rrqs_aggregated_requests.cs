namespace NRPTmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class v_rrqs_aggregated_requests
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal activity_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int inst_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(11)]
        public string activity_status { get; set; }

        public int? workdays_sum { get; set; }

        public int? request_count { get; set; }

        public DateTime? activity_start_dt { get; set; }

        public DateTime? activity_end_dt { get; set; }

        public int? workdays_cancelled_sum { get; set; }

        public int? workdays_deferred_sum { get; set; }
    }
}
