using HospitalAppApi.Data.Repository.IRepository;
using HospitalAppApi.Models;
namespace HospitalAppApi.Data.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private ApplicationDbContext _db; public RoleRepository(ApplicationDbContext db) : base(db) { _db = db; }
        public void Update(Role obj) { _db.Roles.Update(obj); }
    }
}