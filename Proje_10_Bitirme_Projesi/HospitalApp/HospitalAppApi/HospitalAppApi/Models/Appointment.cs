namespace HospitalAppApi.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } // Pending(Bekliyor), Completed(Tamamlandı), Cancelled(İptal)

        // Foreign Keys
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
    }
}