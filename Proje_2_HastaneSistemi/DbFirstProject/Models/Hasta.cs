using System;
using System.Collections.Generic;

namespace DbFirstProject.Models;

public partial class Hasta
{
    public int Id { get; set; }

    public string TcNo { get; set; } = null!;

    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public DateOnly DogumTarihi { get; set; }

    public string Cinsiyet { get; set; } = null!;

    public virtual ICollection<Randevu> Randevus { get; set; } = new List<Randevu>();
}
