namespace HospitalAppApi.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; } // Teşhis
        public string Prescription { get; set; } // Reçete
        public string? Medicines { get; set; } // Kullanılan İlaçlar
        public string? LabAndXRayResults { get; set; } // Röntgen ve Lab Sonuçları
        public DateTime ReportDate { get; set; } = DateTime.Now; // Rapor Tarihi
        public string Notes { get; set; } // Doktor Notları

        // Foreign Key
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}