using System.ComponentModel.DataAnnotations;

namespace OtelProjesi.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public string Type { get; set; } // Oda Tipi (Örn: "Suit", "Tek Kişilik")

        [Required]
        public decimal Price { get; set; } // Günlük Ücreti

        public bool IsAvailable { get; set; } = true; // Oda Boş mu? (Varsayılan: true)
    }
}