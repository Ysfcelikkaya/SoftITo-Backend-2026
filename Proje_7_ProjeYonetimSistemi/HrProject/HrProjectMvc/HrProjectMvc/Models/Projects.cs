using System.ComponentModel.DataAnnotations;

namespace HrProjectMvc.Models
{
    public class Projects
    {
        [Key]
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }

        public int DeveloperId { get; set; }
        //public Developers? Developer { get; set; }

        //public List<Tasks>? Tasks { get; set; }
    }
}
