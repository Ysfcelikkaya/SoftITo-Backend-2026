using System.ComponentModel.DataAnnotations;

namespace OgrenciSistemi.Models
{
    public class Ders
    {
        [Key]
        public int DersNo { get; set; }
        public string DersAdi { get; set; }
        public int DersKredi { get; set; }
    }
}
