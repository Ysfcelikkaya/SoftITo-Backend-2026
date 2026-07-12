using HospitalAppApi.Models;
namespace HospitalAppApi.Data.Repository.IRepository {
    public interface IDepartmentRepository : IRepository<Department> {
        void Update(Department obj);
    } 
}