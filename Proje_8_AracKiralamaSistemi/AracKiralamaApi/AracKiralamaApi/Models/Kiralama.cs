namespace AracKiralamaApi.Models
{
    public class Kiralama
    {
        public int Id { get; set; }

        public int AracId { get; set; }
        public int MusteriId { get; set; }

        public DateTime BaslangicTarih { get; set; }
        public DateTime BitisTarih { get; set; }
    }
}