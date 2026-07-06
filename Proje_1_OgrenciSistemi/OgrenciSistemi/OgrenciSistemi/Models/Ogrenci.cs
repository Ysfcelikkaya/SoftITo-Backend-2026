using System.ComponentModel.DataAnnotations;

namespace OgrenciSistemi.Models
{
    public class Ogrenci
    {
        [Key]
        public int OgrenciNo { get; set; }
        public string OgrenciAdi { get; set; }
        public int OgrenciSinif { get; set; }
        public int BolumNo { get; set; }
        public virtual Bolum bolum { get; set; }
    }
}
