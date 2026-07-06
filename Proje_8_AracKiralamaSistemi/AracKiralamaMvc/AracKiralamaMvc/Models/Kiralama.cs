namespace AracKiralamaMvc.Models
{
    public class Kiralama
    {
        public int Id { get; set; }
        public int AracId { get; set; }
        public int MusteriId { get; set; }
        public DateTime BaslangicTarih { get; set; }
        public DateTime BitisTarih { get; set; }
        public string? Marka { get; set; }
        public string? Model { get; set; }
        public string? AdSoyad { get; set; }
    }
}