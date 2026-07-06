using System.ComponentModel.DataAnnotations;

namespace HrProjectApi.Models
{
    public class Developers
    {
        [Key]
        public int DeveloperId { get; set; }
        public string? DeveloperName { get; set; }
        public DateTime FoundationDate { get; set; }
        public decimal DeveloperValue { get; set; }

        //public List<Projects>? Projects { get; set; }
    }
}
