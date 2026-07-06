using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OgrenciSistemi.Models
{
    public class Ogretmen
    {
        [Key]
        public int OgretmenNo { get; set; }
        public string OgretmenAdi { get; set; }
        public string OgretmenBrans { get; set; }
        public int BolumNo { get; set; }
        [ForeignKey("BolumNo")]
        public virtual Bolum? bolum { get; set; }
    }
}
