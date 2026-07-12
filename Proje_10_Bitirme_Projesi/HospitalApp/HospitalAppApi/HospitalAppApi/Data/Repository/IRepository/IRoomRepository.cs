using HospitalAppApi.Models;
namespace HospitalAppApi.Data.Repository.IRepository {
    public interface IRoomRepository : IRepository<Room> {
        void Update(Room obj);
    } 
}