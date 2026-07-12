namespace HospitalAppMvc.Models
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string Type { get; set; }
        public bool IsOccupied { get; set; }
        public int DepartmentId { get; set; }
    }
}