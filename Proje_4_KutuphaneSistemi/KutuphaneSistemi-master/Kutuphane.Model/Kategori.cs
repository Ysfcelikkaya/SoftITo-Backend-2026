using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kutuphane.Model
{
    public class Kategori
    {
        [Key]
        public int KategoriNo { get; set; }
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
    }
}
