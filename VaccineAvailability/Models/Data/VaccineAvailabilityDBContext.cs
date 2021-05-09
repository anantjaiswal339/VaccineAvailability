using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VaccineAvailability.Models.Data
{
    public partial class VaccineAvailabilityDBContext : DbContext
    {
        public VaccineAvailabilityDBContext()
        {
        }

        public VaccineAvailabilityDBContext(DbContextOptions<VaccineAvailabilityDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AvailableCenter> AvailableCenter { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=MUKESH;Initial Catalog=VaccineAvailabilityDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AvailableCenter>(entity =>
            {
                entity.HasKey(e => e.AvailableCenterId);

                entity.Property(e => e.CurrentDateTime).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.District).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.State).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
