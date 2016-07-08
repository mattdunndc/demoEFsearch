namespace NRPTmodel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class userEDM : DbContext
    {
        public userEDM() : base("name=userEDM")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false; 
        }

        public virtual DbSet<t_user> t_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<t_user>()
                .Property(e => e.user_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_first_nm)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_last_nm)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_actv_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_email_addr_nm)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_wkas_in)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_ntwk_acct_nm)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_grade_lvl_cd)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_dept_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_supervisor_user_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_employee_id)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_grade_step_cd)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_home_zip_code)
                .IsUnicode(false);

            modelBuilder.Entity<t_user>()
                .Property(e => e.user_occupation_cd)
                .IsUnicode(false);
        }
    }
}
