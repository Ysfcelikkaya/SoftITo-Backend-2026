using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmlakProjectORM.Models
{
    public class Favorite
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AppUserId")]
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        [ForeignKey("PropertyId")]
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}