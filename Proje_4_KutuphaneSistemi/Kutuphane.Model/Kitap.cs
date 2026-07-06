using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kutuphane.Model
{
    public class Kitap
    {
        [Key]
        public int KitapNo { get; set; }
        [Required]
        [StringLength(30)]
        public string KitapAdi { get; set; }
        [Required]
        [Range(1, 5000, ErrorMessage = "Bu kitap sizin için uygun değil ")]
        [DisplayName("KitapSayisi")]
        public int KitapSayisi { get; set; }
        public int? KategoriNo { get; set; }
        [ForeignKey("KategoriNo")]
        public Kategori Kategori { get; set; }

        public int? YazarNo { get; set; }

        [ForeignKey("YazarNo")]
        public Yazar? Yazar { get; set; }
    }
}
