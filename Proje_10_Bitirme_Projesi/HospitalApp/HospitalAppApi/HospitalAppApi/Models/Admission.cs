namespace HospitalAppApi.Models
{
    public class Admission
    {
        public int Id { get; set; }
        public DateTime AdmissionDate { get; set; } // Yatış Tarihi
        public DateTime? DischargeDate { get; set; } // Taburcu Tarihi (Hastanedeyse boş kalır)

        // Foreign Keys
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}