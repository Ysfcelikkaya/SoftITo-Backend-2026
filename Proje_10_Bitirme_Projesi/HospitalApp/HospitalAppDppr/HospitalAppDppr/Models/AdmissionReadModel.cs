namespace HospitalAppDppr.Models 
{ 
    public class AdmissionReadModel 
    {
        public int Id { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime? DischargeDate { get; set; } 
        public string RoomNumber { get; set; }
    }
}