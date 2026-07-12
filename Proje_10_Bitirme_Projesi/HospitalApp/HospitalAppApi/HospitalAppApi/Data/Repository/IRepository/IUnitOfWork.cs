using HospitalAppApi.Models;

namespace HospitalAppApi.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        // 10 Tablomuzun Tamamı İçin Repository'ler
        IUserRepository Users { get; }
        IPatientRepository Patient { get; }
        IDoctorRepository Doctor { get; }
        IAppointmentRepository Appointment { get; }
        IRoleRepository Role { get; }
        IDepartmentRepository Department { get; }
        IRoomRepository Room { get; }
        IAdmissionRepository Admission { get; }
        IMedicalRecordRepository MedicalRecord { get; }
        IInvoiceRepository Invoice { get; }

        // Veritabanına kaydetme metotları
        Task<int> CommitAsync();
        void Commit();
    }
}