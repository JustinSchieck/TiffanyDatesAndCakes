namespace TiffanysDatesandCakes.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<CakeDate> CakeDates { get; set; }
        public virtual DbSet<Cake> Cakes { get; set; }
        public virtual DbSet<Date> Dates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cake>()
                .HasMany(e => e.CakeDates)
                .WithRequired(e => e.Cake)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Date>()
                .HasMany(e => e.CakeDates)
                .WithRequired(e => e.Date)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Date>()
                .HasMany(e => e.Cakes)
                .WithRequired(e => e.Date)
                .WillCascadeOnDelete(false);
        }
    }
}
