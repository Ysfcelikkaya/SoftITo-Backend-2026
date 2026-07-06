using System.ComponentModel.DataAnnotations;

namespace OgrenciSistemi.Models

{
    public class Bolum
    {
        [Key]
        public int BolumNo { get; set; }
        public string BolumAdi { get; set; }
    }
}
