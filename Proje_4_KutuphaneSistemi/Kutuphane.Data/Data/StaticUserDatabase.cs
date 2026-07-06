using System.Collections.Generic;
using Kutuphane.Model; // Sizin Model katmanınızın namespace'i

namespace Kutuphane.Data // Sizin Data katmanınızın namespace'i
{
    public static class StaticUserDatabase
    {
        // Başlangıçta giriş yapabilmeniz için 1 adet Admin koydum
        public static List<Kullanici> Kullanicilar = new List<Kullanici>()
        {
            new Kullanici { Id = "1", AdSoyad = "Kütüphane Yöneticisi", Username = "admin", Password = "123" }
        };
    }
}