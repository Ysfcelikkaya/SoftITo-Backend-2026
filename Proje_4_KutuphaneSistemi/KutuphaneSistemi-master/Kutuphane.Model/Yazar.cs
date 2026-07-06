using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kutuphane.Model
{
        public class Yazar
        {
            [Key]
            public int YazarNo { get; set; }

            [Required(ErrorMessage = "Yazar adı boş geçilemez")]
            [StringLength(50, ErrorMessage = "Yazar adı en fazla {1} karakter olabilir")]
            public string YazarAdi { get; set; }
            public ICollection<Kitap>? Kitaps { get; set; }
        }
    }
