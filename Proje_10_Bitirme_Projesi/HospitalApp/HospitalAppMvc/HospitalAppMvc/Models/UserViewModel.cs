namespace HospitalAppMvc.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string? PasswordHash { get; set; } // Şifre
        public int RoleId { get; set; } // 1: Admin, 2: Patient, 3: Doctor
        public bool IsActive { get; set; } = true;
    }
}