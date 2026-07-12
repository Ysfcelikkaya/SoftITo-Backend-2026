using HospitalAppApi.Data.Repository.IRepository;
using HospitalAppApi.Models;

namespace HospitalAppApi.Data.Repository
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private ApplicationDbContext _db;
        public DoctorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Doctor obj)
        {
            _db.Doctors.Update(obj);
        }
    }
}