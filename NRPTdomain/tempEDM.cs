namespace NRPTmodel.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class tempEDM : DbContext
    {
        public tempEDM()
            : base("name=tempEDM")
        {
        }

        public virtual DbSet<t_rrcs_city_state_near_rrlc> t_rrcs_city_state_near_rrlc { get; set; }
        public virtual DbSet<t_rrdp_rrqs_dept_ref> t_rrdp_rrqs_dept_ref { get; set; }
        public virtual DbSet<t_rrfa_rrqs_funct_area_ref> t_rrfa_rrqs_funct_area_ref { get; set; }
        public virtual DbSet<t_stcd_state_cd> t_stcd_state_cd { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<t_rrcs_city_state_near_rrlc>()
                .Property(e => e.rrcs_id)
                .HasPrecision(6, 0);

            modelBuilder.Entity<t_rrcs_city_state_near_rrlc>()
                .Property(e => e.rrcs_state_cd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrcs_city_state_near_rrlc>()
                .Property(e => e.rrcs_city_nm)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrcs_city_state_near_rrlc>()
                .Property(e => e.rrcs_active_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrcs_city_state_near_rrlc>()
                .Property(e => e.rrcs_country_nm)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrdp_rrqs_dept_ref>()
                .Property(e => e.rrdp_dept_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrdp_rrqs_dept_ref>()
                .Property(e => e.rrdp_district_cd)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrdp_rrqs_dept_ref>()
                .Property(e => e.rrdp_active_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrdp_rrqs_dept_ref>()
                .Property(e => e.rrdp_route_to_dept_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrfa_rrqs_funct_area_ref>()
                .Property(e => e.rrfa_cd)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrfa_rrqs_funct_area_ref>()
                .Property(e => e.rrfa_function_area_tx)
                .IsUnicode(false);

            modelBuilder.Entity<t_rrfa_rrqs_funct_area_ref>()
                .Property(e => e.rrfa_complexity_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrfa_rrqs_funct_area_ref>()
                .Property(e => e.rrfa_nrpt_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrfa_rrqs_funct_area_ref>()
                .Property(e => e.rrfa_stars_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrfa_rrqs_funct_area_ref>()
                .Property(e => e.rrfa_ev_work_day_cat_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrfa_rrqs_funct_area_ref>()
                .Property(e => e.rrfa_feic_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_rrfa_rrqs_funct_area_ref>()
                .Property(e => e.rrfa_mrat_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_stcd_state_cd>()
                .Property(e => e.stcd_state_abbrv)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_stcd_state_cd>()
                .Property(e => e.stcd_state_desc)
                .IsUnicode(false);

            modelBuilder.Entity<t_stcd_state_cd>()
                .HasMany(e => e.t_rrcs_city_state_near_rrlc)
                .WithRequired(e => e.t_stcd_state_cd)
                .HasForeignKey(e => e.rrcs_state_cd)
                .WillCascadeOnDelete(false);
        }
    }
}
