using System;

namespace HospitalAppMvc.Models
{
    public class AdmissionViewModel
    {
        public int Id { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime? DischargeDate { get; set; } // Çıkış yapılmamışsa boş kalır

        // API'ye gönderilecek ID'ler
        public int PatientId { get; set; }
        public int RoomId { get; set; }

        // Ekranda (Listede) gösterilecek isimler
        public string? PatientName { get; set; }
        public string? RoomNumber { get; set; }
        public bool IsActive { get; set; } // Yatış devam ediyor mu?
    }
}