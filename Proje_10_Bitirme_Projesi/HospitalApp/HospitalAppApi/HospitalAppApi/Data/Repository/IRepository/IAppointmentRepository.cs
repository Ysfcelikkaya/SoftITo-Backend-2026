using HospitalAppApi.Models;
namespace HospitalAppApi.Data.Repository.IRepository
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        void Update(Appointment obj);
    }
}