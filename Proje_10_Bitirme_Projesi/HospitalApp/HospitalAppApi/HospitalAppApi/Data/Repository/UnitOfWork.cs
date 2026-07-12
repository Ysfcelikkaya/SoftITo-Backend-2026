using HospitalAppApi.Data.Repository.IRepository;

namespace HospitalAppApi.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserRepository Users { get; private set; }
        public IPatientRepository Patient { get; private set; }
        public IDoctorRepository Doctor { get; private set; }
        public IAppointmentRepository Appointment { get; private set; }

        // Yeni Eklenenler
        public IRoleRepository Role { get; private set; }
        public IDepartmentRepository Department { get; private set; }
        public IRoomRepository Room { get; private set; }
        public IAdmissionRepository Admission { get; private set; }
        public IMedicalRecordRepository MedicalRecord { get; private set; }
        public IInvoiceRepository Invoice { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Users = new UserRepository(_context);
            Patient = new PatientRepository(_context);
            Doctor = new DoctorRepository(_context);
            Appointment = new AppointmentRepository(_context);

            // Yeni Eklenenler
            Role = new RoleRepository(_context);
            Department = new DepartmentRepository(_context);
            Room = new RoomRepository(_context);
            Admission = new AdmissionRepository(_context);
            MedicalRecord = new MedicalRecordRepository(_context);
            Invoice = new InvoiceRepository(_context);
        }

        public void Commit() { _context.SaveChanges(); }
        public async Task<int> CommitAsync() { return await _context.SaveChangesAsync(); }
        public void Dispose() { _context.Dispose(); }
    }
}