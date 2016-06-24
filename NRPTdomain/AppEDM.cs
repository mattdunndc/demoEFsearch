namespace NRPTmodel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AppEDM : DbContext
    {
        public AppEDM()
            : base("name=AppEDM")
        {
        }

        public virtual DbSet<t_prap_proj_scad> t_prap_proj_scad { get; set; }
        public virtual DbSet<t_scad_app_def> t_scad_app_def { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<t_scad_app_def>()
                .Property(e => e.scad_app_nm)
                .IsUnicode(false);

            modelBuilder.Entity<t_scad_app_def>()
                .Property(e => e.scad_description_tx)
                .IsUnicode(false);

            modelBuilder.Entity<t_scad_app_def>()
                .Property(e => e.scad_district_access_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_scad_app_def>()
                .HasMany(e => e.t_prap_proj_scad)
                .WithRequired(e => e.t_scad_app_def)
                .HasForeignKey(e => e.prap_scad_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_prap_proj_scad>()
                .Property(e => e.prap_scad_id);

        }
    }
}
