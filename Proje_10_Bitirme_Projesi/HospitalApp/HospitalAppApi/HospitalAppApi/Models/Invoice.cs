namespace HospitalAppApi.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime IssueDate { get; set; }
        public string Status { get; set; } // Paid(Ödendi), Unpaid(Ödenmedi)

        // Foreign Key
        public int? AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public int? AdmissionId { get; set; }
        public Admission Admission { get; set; }
    }
}