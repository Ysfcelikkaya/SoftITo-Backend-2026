using System.ComponentModel.DataAnnotations;

namespace HospitalAppApi.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; } // Prof., Uzman, vb.

        // Foreign Keys
        public int UserId { get; set; }
        public User? User { get; set; }

        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}