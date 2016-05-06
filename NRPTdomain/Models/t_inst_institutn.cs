namespace NRPTmodel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_inst_institutn
    {
        public t_inst_institutn()
        {
            t_rrac_activity = new HashSet<t_rrac_activity>();
            t_rrqs_resource_request = new HashSet<t_rrqs_resource_request>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int inst_id { get; set; }

        public int inst_occ_asgnd_id { get; set; }

        [StringLength(40)]
        public string inst_short_name { get; set; }

        [StringLength(30)]
        public string inst_loc_city_name { get; set; }

        [StringLength(2)]
        public string inst_loc_st_abbrv { get; set; }

        [StringLength(9)]
        public string inst_loc_zip_code { get; set; }

        public short inst_inty_cd { get; set; }

        public int? inst_hhc_id { get; set; }

        public DateTime inst_last_updt_ts { get; set; }

        [StringLength(60)]
        public string inst_loc_addr1 { get; set; }

        [StringLength(60)]
        public string inst_loc_addr2 { get; set; }

        [StringLength(120)]
        public string inst_full_name { get; set; }

        public DateTime? inst_charter_dt { get; set; }

        public int? inst_fdic_cert_id { get; set; }

        [Required]
        [StringLength(1)]
        public string inst_actv_in { get; set; }

        public DateTime? inst_dnld_strt_ts { get; set; }

        public DateTime? inst_inactv_dt { get; set; }

        [StringLength(3)]
        public string inst_csrv_cd { get; set; }

        public short? inst_tr_powers_cd { get; set; }

        public int? inst_frb_rssd_nr { get; set; }

        [StringLength(30)]
        public string inst_mail_city_nm { get; set; }

        [StringLength(60)]
        public string inst_mail_addr1 { get; set; }

        [StringLength(60)]
        public string inst_mail_addr2 { get; set; }

        [StringLength(2)]
        public string inst_mail_st_abbrv { get; set; }

        [StringLength(9)]
        public string inst_mail_zip_code { get; set; }

        [StringLength(2)]
        public string inst_supv_clas_cd { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? inst_occ_dllrs_am { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? inst_fdic_dllrs_am { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? inst_frb_dllrs_am { get; set; }

        public int? inst_dhc_id { get; set; }

        [StringLength(2)]
        public string inst_canry_stat_cd { get; set; }

        public DateTime? inst_canry_rpt_dt { get; set; }

        [StringLength(1)]
        public string inst_fdic_ins_cd { get; set; }

        [StringLength(10)]
        public string inst_supv_dept_id { get; set; }

        [StringLength(10)]
        public string inst_geo_dept_id { get; set; }

        [StringLength(10)]
        public string inst_adc_dept_id { get; set; }

        public int? inst_occ_top_inst_id { get; set; }

        public int? inst_occ_own_inst_id { get; set; }

        [StringLength(60)]
        public string inst_loc_ctry_nm { get; set; }

        [StringLength(8)]
        public string inst_regulator_cd { get; set; }

        [StringLength(1)]
        public string inst_sarbanes_oxley_req_in { get; set; }

        [StringLength(1)]
        public string inst_sarbanes_oxley_cmplnt_in { get; set; }

        [StringLength(1)]
        public string inst_tfag_in { get; set; }

        public int? inst_sub_data_size_kb { get; set; }

        [StringLength(10)]
        public string inst_ocws_worksite_cd { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? inst_ots_dllrs_am { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? inst_ots_docket_nr { get; set; }

        [StringLength(6)]
        public string inst_ots_owner_nr { get; set; }

        [StringLength(10)]
        public string inst_thrift_stock_mutual_tx { get; set; }

        public DateTime inst_ml_server_chg_ts { get; set; }

        public decimal? inst_latest_asset_am { get; set; }

        public DateTime? inst_asset_fin_as_of_dt { get; set; }

        [StringLength(15)]
        public string inst_abbrv_nm { get; set; }

        public virtual ICollection<t_rrac_activity> t_rrac_activity { get; set; }

        public virtual ICollection<t_rrqs_resource_request> t_rrqs_resource_request { get; set; }
    }
}
