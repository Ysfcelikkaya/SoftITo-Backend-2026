using HospitalAppApi.Data.Repository.IRepository;
using HospitalAppApi.Models;

namespace HospitalAppApi.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(User obj)
        {
            _db.Users.Update(obj);
        }
    }
}