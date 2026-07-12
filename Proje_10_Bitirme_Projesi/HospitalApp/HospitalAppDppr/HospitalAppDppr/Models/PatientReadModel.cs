namespace HospitalAppDppr.Models
{
    public class PatientReadModel
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BloodGroup { get; set; }
    }
}