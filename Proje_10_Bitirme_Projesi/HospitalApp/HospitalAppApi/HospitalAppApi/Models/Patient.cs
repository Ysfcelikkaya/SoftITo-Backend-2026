namespace HospitalAppApi.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; } // TCKN
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodGroup { get; set; }

        // Foreign Key
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}