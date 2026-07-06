using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmlakProjectORM.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } // İlan Başlığı

        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; } // Fiyat

        public int Rooms { get; set; } // Oda sayısı
        public int SquareMeters { get; set; } // Metrekare

        public string? Photo { get; set; } // Resim yolunu tutacağımız kolon

        // PropertyType ile bağlantı (Combobox için)
        [ForeignKey("PropertyTypeId")]
        public int PropertyTypeId { get; set; }
        public PropertyType PropertyType { get; set; }
    }
}