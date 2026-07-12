namespace HospitalAppDppr.Models
{
    public class AppointmentReadModel
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Notes { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
    }
}