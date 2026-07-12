namespace HospitalAppDppr.Models
{ 
    public class InvoiceReadModel 
    { 
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime IssueDate { get; set; }
        public bool IsPaid { get; set; }
    } 
}