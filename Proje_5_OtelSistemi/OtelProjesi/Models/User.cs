using System.ComponentModel.DataAnnotations;

namespace OtelProjesi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } // Adı Soyadı

        [Required]
        public string Email { get; set; } // E-posta adresi

        [Required]
        public string PhoneNumber { get; set; } // Telefon Numarası
    }
}