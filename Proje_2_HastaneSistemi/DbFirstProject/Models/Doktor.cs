using System;
using System.Collections.Generic;

namespace DbFirstProject.Models;

public partial class Doktor
{
    public int Id { get; set; }

    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public string UzmanlikAlani { get; set; } = null!;

    public string? Telefon { get; set; }

    public virtual ICollection<Randevu> Randevus { get; set; } = new List<Randevu>();
}
