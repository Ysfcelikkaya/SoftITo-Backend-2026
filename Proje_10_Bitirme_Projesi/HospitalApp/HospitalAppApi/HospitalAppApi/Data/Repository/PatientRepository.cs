using HospitalAppApi.Data.Repository.IRepository;
using HospitalAppApi.Models;

namespace HospitalAppApi.Data.Repository
{
    // Hem temel Repository<Patient>'den miraz alıyoruz, hem de IPatientRepository kurallarına uyuyoruz
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private ApplicationDbContext _db;

        public PatientRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Patient obj)
        {
            _db.Patients.Update(obj);
        }
    }
}