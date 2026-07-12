using System;

namespace HospitalAppMvc.Models
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; } // Fatura Kesim Tarihi
        public decimal Amount { get; set; } // Fatura Tutarı (₺)
        public string Status { get; set; } // "Paid" (Ödendi) veya "Unpaid" (Ödenmedi)

        // Fatura artık Hastaya değil, girdiği Randevuya (Appointment) kesiliyor!
        public int? AppointmentId { get; set; }
        public int? AdmissionId { get; set; }

        // Sadece ekranda okumak için
        public string? PatientName { get; set; }
    }
}