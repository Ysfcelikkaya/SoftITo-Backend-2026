using HospitalAppApi.Data.Repository.IRepository;
using HospitalAppApi.Models;
namespace HospitalAppApi.Data.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private ApplicationDbContext _db; public RoomRepository(ApplicationDbContext db) : base(db) { _db = db; }
        public void Update(Room obj) { _db.Rooms.Update(obj); }
    }
}