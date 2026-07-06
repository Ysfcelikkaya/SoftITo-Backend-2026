using System.ComponentModel.DataAnnotations;

namespace EmlakProjectORM.Models
{
    public class PropertyType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TypeName { get; set; } // Örn: Satılık Daire, Kiralık Dükkan

        public string Description { get; set; }
    }
}