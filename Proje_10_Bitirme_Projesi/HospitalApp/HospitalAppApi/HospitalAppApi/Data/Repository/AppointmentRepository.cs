using HospitalAppApi.Data.Repository.IRepository;
using HospitalAppApi.Models;

namespace HospitalAppApi.Data.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private ApplicationDbContext _db;
        public AppointmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Appointment obj)
        {
            _db.Appointments.Update(obj);
        }
    }
}