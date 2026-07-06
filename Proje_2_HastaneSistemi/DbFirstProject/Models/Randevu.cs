using System;
using System.Collections.Generic;

namespace DbFirstProject.Models;

public partial class Randevu
{
    public int Id { get; set; }

    public int HastaId { get; set; }

    public int DoktorId { get; set; }

    public DateTime RandevuTarihi { get; set; }

    public string? Sikayet { get; set; }

    public virtual Doktor Doktor { get; set; } = null!;

    public virtual Hasta Hasta { get; set; } = null!;
}
