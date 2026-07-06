using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace odevrzrpg.Pages.Satislar
{
    public class CreateModel : PageModel
    {
        public Satis satisbilgi = new Satis();

        // Ürün adlarını ve fiyatlarını tutacak liste
        public List<KeyValuePair<string, string>> UrunListesi { get; set; } = new List<KeyValuePair<string, string>>();

        // Müşteri adlarını tutacak liste
        public List<string> MusteriListesi { get; set; } = new List<string>();

        public string errorMessage = "";
        public string successMessage = "";

        string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=StokTakipDB;Integrated Security=true;TrustServerCertificate=true;";

        public void OnGet()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // 1. Ürünleri Çekiyoruz
                    string sqlUrun = "SELECT UrunAdi, Fiyat FROM Urunler";
                    using (SqlCommand cmdUrun = new SqlCommand(sqlUrun, connection))
                    {
                        using (SqlDataReader reader = cmdUrun.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UrunListesi.Add(new KeyValuePair<string, string>(reader.GetString(0), reader.GetValue(1).ToString()));
                            }
                        }
                    }

                    // 2. Müşterileri Çekiyoruz
                    string sqlMusteri = "SELECT AdSoyad FROM Musteriler";
                    using (SqlCommand cmdMusteri = new SqlCommand(sqlMusteri, connection))
                    {
                        using (SqlDataReader reader = cmdMusteri.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MusteriListesi.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Veriler yüklenirken hata oluştu: " + ex.Message;
            }
        }

        public void OnPost()
        {
            satisbilgi.MusteriAdSoyad = Request.Form["MusteriAdSoyad"];
            satisbilgi.UrunAdi = Request.Form["UrunAdi"];
            satisbilgi.Adet = Request.Form["Adet"];
            satisbilgi.ToplamTutar = Request.Form["ToplamTutar"];

            if (string.IsNullOrEmpty(satisbilgi.MusteriAdSoyad) || string.IsNullOrEmpty(satisbilgi.UrunAdi) ||
                string.IsNullOrEmpty(satisbilgi.Adet) || string.IsNullOrEmpty(satisbilgi.ToplamTutar))
            {
                errorMessage = "Lütfen tüm alanları eksiksiz doldurun!";
                OnGet();
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // 1. ADIM: Satış Geçmişine Kayıt Ekleme
                    string sqlSatis = "INSERT INTO Satislar (MusteriAdSoyad, UrunAdi, Adet, ToplamTutar) " +
                                      "VALUES (@MusteriAdSoyad, @UrunAdi, @Adet, @ToplamTutar)";

                    using (SqlCommand cmdSatis = new SqlCommand(sqlSatis, connection))
                    {
                        cmdSatis.Parameters.AddWithValue("@MusteriAdSoyad", satisbilgi.MusteriAdSoyad);
                        cmdSatis.Parameters.AddWithValue("@UrunAdi", satisbilgi.UrunAdi);
                        cmdSatis.Parameters.AddWithValue("@Adet", int.Parse(satisbilgi.Adet));
                        cmdSatis.Parameters.AddWithValue("@ToplamTutar", decimal.Parse(satisbilgi.ToplamTutar.Replace(",", ".")));

                        cmdSatis.ExecuteNonQuery();
                    }

                    // 2. ADIM: Ürünün Stoğunu Satılan Adet Kadar Azaltma
                    string sqlStokDus = "UPDATE Urunler SET StokAdeti = StokAdeti - @SatilanAdet WHERE UrunAdi = @UrunAdi";
                    using (SqlCommand cmdStok = new SqlCommand(sqlStokDus, connection))
                    {
                        cmdStok.Parameters.AddWithValue("@SatilanAdet", int.Parse(satisbilgi.Adet));
                        cmdStok.Parameters.AddWithValue("@UrunAdi", satisbilgi.UrunAdi);

                        cmdStok.ExecuteNonQuery();
                    }

                    // 3. ADIM: Müşterinin Bakiyesini Satış Tutarı Kadar Doğrudan Azaltma
                    // Musteriler tablosundaki mevcut bakiyeden, bu satışın toplam tutarını matematiksel olarak düşüyoruz.
                    string sqlBakiyeDus = "UPDATE Musteriler SET Bakiye = CAST(REPLACE(Bakiye, ',', '.') AS DECIMAL(18,2)) - @ToplamTutar WHERE AdSoyad = @MusteriAdSoyad";
                    using (SqlCommand cmdBakiye = new SqlCommand(sqlBakiyeDus, connection))
                    {
                        cmdBakiye.Parameters.AddWithValue("@ToplamTutar", decimal.Parse(satisbilgi.ToplamTutar.Replace(",", ".")));
                        cmdBakiye.Parameters.AddWithValue("@MusteriAdSoyad", satisbilgi.MusteriAdSoyad);

                        cmdBakiye.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                OnGet();
                return;
            }

            Response.Redirect("/Satislar/Index");
        }
    }
}