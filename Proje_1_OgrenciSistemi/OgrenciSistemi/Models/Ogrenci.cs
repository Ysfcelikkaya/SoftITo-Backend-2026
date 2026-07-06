using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OgrenciSistemi.Models
{ 
    public class Ogrenci
    {
        [Key]
        public int OgrenciNo { get; set; }
        public string OgrenciAdi { get; set; }
        public int OgrenciSinif { get; set; }
        public int BolumNo { get; set; }
        [ForeignKey("BolumNo")]
        public virtual Bolum? bolum { get; set; }
    }
}
