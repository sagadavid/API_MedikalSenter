using API_MedikalSenter.Models;
using Microsoft.EntityFrameworkCore;

namespace API_MedikalSenter.Data
{
    public class Api_MedikalSenterContext : DbContext
    {
        public Api_MedikalSenterContext(DbContextOptions<Api_MedikalSenterContext> options)
           : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
            .HasIndex(p => p.OHIP)
            .IsUnique();

            modelBuilder.Entity<Doctor>()
                .HasMany<Patient>(d => d.Patients)
                .WithOne(p => p.Doctor)
                .HasForeignKey(p => p.DoctorID)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
