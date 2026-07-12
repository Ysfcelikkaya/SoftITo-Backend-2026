using HospitalAppApi.Data.Repository.IRepository;
using HospitalAppApi.Models;
namespace HospitalAppApi.Data.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private ApplicationDbContext _db; public DepartmentRepository(ApplicationDbContext db) : base(db) { _db = db; }
        public void Update(Department obj) { _db.Departments.Update(obj); }
    }
}