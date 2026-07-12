namespace HospitalAppDppr.Models
{ 
    public class MedicalRecordReadModel
    {
        public int Id { get; set; } 
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public DateTime RecordDate { get; set; }
    } 
}