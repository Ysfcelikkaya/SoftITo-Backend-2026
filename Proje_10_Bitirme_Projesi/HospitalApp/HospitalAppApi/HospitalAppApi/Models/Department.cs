using System.Numerics;

namespace HospitalAppApi.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } // Kardiyoloji, Göz vb.
        public string Description { get; set; }

        // İlişkiler
        public ICollection<Doctor> Doctors { get; set; }
    }
}