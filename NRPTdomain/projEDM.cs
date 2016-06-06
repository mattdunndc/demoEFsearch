namespace NRPTmodel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class projEDM : DbContext
    {
        public projEDM()
            : base("name=projEDM")
        {
        }

        public virtual DbSet<t_prdp_proj_dept> t_prdp_proj_dept { get; set; }
        public virtual DbSet<t_prin_proj_inst> t_prin_proj_inst { get; set; }
        public virtual DbSet<t_proj_project> t_proj_project { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<t_prdp_proj_dept>()
                .Property(e => e.prdp_dept_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_proj_project>()
                .Property(e => e.proj_project_nm)
                .IsUnicode(false);

            modelBuilder.Entity<t_proj_project>()
                .Property(e => e.pobj_project_type_cd)
                .IsUnicode(false);

            modelBuilder.Entity<t_proj_project>()
                .Property(e => e.proj_contact_user_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_proj_project>()
                .Property(e => e.proj_active_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_proj_project>()
                .Property(e => e.proj_last_updt_user_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_proj_project>()
                .HasMany(e => e.t_prdp_proj_dept)
                .WithRequired(e => e.t_proj_project)
                .HasForeignKey(e => e.prdp_proj_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_proj_project>()
                .HasMany(e => e.t_prin_proj_inst)
                .WithRequired(e => e.t_proj_project)
                .HasForeignKey(e => e.prin_proj_id)
                .WillCascadeOnDelete(false);
        }
    }
}
