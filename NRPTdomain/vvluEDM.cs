namespace NRPTmodel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class vvluEDM : DbContext
    {
        public vvluEDM()
            : base("name=vvluEDM")
        {
        }

        public virtual DbSet<t_vvlu_valid_value> t_vvlu_valid_value { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<t_vvlu_valid_value>()
                .Property(e => e.vvlu_col_nm)
                .IsUnicode(false);

            modelBuilder.Entity<t_vvlu_valid_value>()
                .Property(e => e.vvlu_char_vlu_cd)
                .IsUnicode(false);

            modelBuilder.Entity<t_vvlu_valid_value>()
                .Property(e => e.vvlu_desc_tx)
                .IsUnicode(false);

            modelBuilder.Entity<t_vvlu_valid_value>()
                .Property(e => e.vvlu_envr_spcfc_in)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
