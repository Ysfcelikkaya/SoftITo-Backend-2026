namespace HospitalAppApi.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } // Admin, Doctor, Patient

        // İlişkiler
        public ICollection<User> Users { get; set; }
    }
}