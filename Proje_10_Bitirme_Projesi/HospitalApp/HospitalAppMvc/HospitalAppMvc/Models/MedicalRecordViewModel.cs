using System;

namespace HospitalAppMvc.Models
{
    public class MedicalRecordViewModel
    {
        public int Id { get; set; }
        public DateTime RecordDate { get; set; } // Muayene Tarihi
        public string Diagnosis { get; set; } // Tanı / Hastalık
        public string Prescription { get; set; } // Reçete / İlaçlar
        public string Notes { get; set; } // Doktor Notu
        public string? Medicines { get; set; } // Kullanılan İlaçlar
        public string? LabAndXRayResults { get; set; } // Röntgen ve Lab Sonuçları
        public DateTime ReportDate { get; set; } = DateTime.Now; // Rapor Tarihi
        public int AppointmentId { get; set; }
        // API'den gelen veya gidecek olan ID'ler
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        // Ekranda listelenirken gösterilecek isimler
        public string? PatientName { get; set; }
        public string? DoctorName { get; set; }
    }
}