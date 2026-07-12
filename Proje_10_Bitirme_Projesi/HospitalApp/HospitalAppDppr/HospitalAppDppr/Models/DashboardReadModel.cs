namespace HospitalAppDppr.Models
{
    public class DashboardReadModel
    {
        public int TotalPatients { get; set; }
        public int TotalDoctors { get; set; }
        public int TotalAppointments { get; set; }
        public decimal TotalRevenue { get; set; } // Toplam Ciro
    }
}