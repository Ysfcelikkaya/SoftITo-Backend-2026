using HospitalAppApi.Models;
namespace HospitalAppApi.Data.Repository.IRepository
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        void Update(Doctor obj);
    }
}