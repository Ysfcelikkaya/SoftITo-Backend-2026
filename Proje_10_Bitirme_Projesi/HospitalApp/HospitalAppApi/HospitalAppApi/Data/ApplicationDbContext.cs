using Microsoft.EntityFrameworkCore;
using HospitalAppApi.Models; // Modellerimizin bulunduğu yeri ekliyoruz

namespace HospitalAppApi.Data // Eğer Data klasörü açmadıysanız sadece namespace HospitalAppApi yapabilirsiniz
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Veritabanında oluşacak tablolarımız:
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Admission> Admissions { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Doktor silinirse randevuları otomatik silme!
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany()
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Hasta silinirse randevuları otomatik silme!
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany()
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            // (Aynı şekilde Yatışlar tablosu için de kilitlenmeyi önleyelim)
            modelBuilder.Entity<Admission>()
                .HasOne(a => a.Patient)
                .WithMany()
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}