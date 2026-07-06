
namespace Kutuphane.Model // Kendi projenizin ismine göre değiştirin
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterViewModel
    {
        public string AdSoyad { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
