namespace HospitalAppApi.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string Type { get; set; }
        public bool IsOccupied { get; set; } = false;

        // SADECE ID BİZE YETERLİ
        public int DepartmentId { get; set; }

        // BUNLARIN SONUNA SORU İŞARETİ KOYUYORUZ:
        public Department? Department { get; set; }
        public ICollection<Admission>? Admissions { get; set; }
    }
}