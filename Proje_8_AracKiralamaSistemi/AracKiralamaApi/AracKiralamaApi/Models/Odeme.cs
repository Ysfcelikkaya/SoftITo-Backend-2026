namespace AracKiralamaApi.Models
{
    public class Odeme
    {
        public int Id { get; set; }

        public int KiralamaId { get; set; }
        public decimal Tutar { get; set; }
        public DateTime OdemeTarihi { get; set; }
    }
}