using HospitalAppApi.Data.Repository.IRepository;
using HospitalAppApi.Models;
namespace HospitalAppApi.Data.Repository
{
    public class MedicalRecordRepository : Repository<MedicalRecord>, IMedicalRecordRepository
    {
        private ApplicationDbContext _db; public MedicalRecordRepository(ApplicationDbContext db) : base(db) { _db = db; }
        public void Update(MedicalRecord obj) { _db.MedicalRecords.Update(obj); }
    }
}