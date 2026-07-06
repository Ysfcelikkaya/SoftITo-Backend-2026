using System.ComponentModel.DataAnnotations;

namespace HrProjectApi.Models
{
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }
        public string? TaskTitle { get; set; }
        public string? Status { get; set; }

        public int ProjectId { get; set; }
        //public Projects? Project { get; set; }
    }
}
