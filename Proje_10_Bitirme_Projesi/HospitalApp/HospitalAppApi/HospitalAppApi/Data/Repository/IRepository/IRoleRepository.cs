using HospitalAppApi.Models;
namespace HospitalAppApi.Data.Repository.IRepository {
    public interface IRoleRepository : IRepository<Role> {
        void Update(Role obj);
    } 
}