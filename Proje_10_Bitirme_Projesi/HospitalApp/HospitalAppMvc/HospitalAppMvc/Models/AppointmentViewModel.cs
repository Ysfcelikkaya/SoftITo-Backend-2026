using System;

namespace HospitalAppMvc.Models
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? Status { get; set; }

        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string? PatientName { get; set; }
        public string? DoctorName { get; set; }
        public string? DepartmentName { get; set; }
    }
}