using EmlakProjectORM.Data.Repository.IRepository;
using EmlakProjectORM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmlakProjectORM.Data.Repository
{
    public class AppointmentRepository: Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext context) : base(context) { }
    }
}
