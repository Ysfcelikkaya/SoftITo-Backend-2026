using HospitalAppApi.Data.Repository.IRepository;
using HospitalAppApi.Models;
namespace HospitalAppApi.Data.Repository
{
    public class AdmissionRepository : Repository<Admission>, IAdmissionRepository
    {
        private ApplicationDbContext _db; public AdmissionRepository(ApplicationDbContext db) : base(db) { _db = db; }
        public void Update(Admission obj) { _db.Admissions.Update(obj); }
    }
}