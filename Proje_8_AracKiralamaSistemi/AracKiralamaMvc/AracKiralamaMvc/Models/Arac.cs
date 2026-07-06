namespace AracKiralamaMvc.Models
{
    public class Arac
    {
        public int Id { get; set; }
        public string? Marka { get; set; }
        public string? Model { get; set; }
        public int Yil { get; set; }
        public decimal GunlukUcret { get; set; }
    }
}