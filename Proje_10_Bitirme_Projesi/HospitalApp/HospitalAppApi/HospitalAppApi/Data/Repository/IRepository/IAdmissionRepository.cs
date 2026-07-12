using HospitalAppApi.Models;
namespace HospitalAppApi.Data.Repository.IRepository {
    public interface IAdmissionRepository : IRepository<Admission> {
        void Update(Admission obj);
    } 
}