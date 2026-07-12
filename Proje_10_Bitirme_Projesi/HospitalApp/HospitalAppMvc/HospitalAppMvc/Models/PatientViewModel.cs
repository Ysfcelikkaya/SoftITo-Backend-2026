namespace HospitalAppMvc.Models
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BloodGroup { get; set; }
        public int UserId { get; set; }
    }
}