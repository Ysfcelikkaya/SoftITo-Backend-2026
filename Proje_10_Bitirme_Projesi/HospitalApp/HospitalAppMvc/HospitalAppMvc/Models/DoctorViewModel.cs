namespace HospitalAppMvc.Models
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; } // Hangi kullanıcıya ait
        public int DepartmentId { get; set; } // Hangi bölüme ait
    }
}