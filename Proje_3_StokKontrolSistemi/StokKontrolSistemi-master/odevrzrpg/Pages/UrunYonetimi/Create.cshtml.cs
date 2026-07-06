using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using odevrzrpg.Pages.UrunYonetimi;
using System.Data.SqlClient;

namespace odevrzrpg.Pages.UrunYonetimi
{
    public class CreateModel : PageModel
    {
        public Urun urunbilgi = new Urun();
        public string errorMessage = "";
        public string successMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            urunbilgi.UrunAdi = Request.Form["UrunAdi"];
            urunbilgi.Kategori = Request.Form["Kategori"];
            urunbilgi.Fiyat = Request.Form["Fiyat"];
            urunbilgi.StokAdeti = Request.Form["StokAdeti"];
            urunbilgi.KayitTarihi = Request.Form["KayitTarihi"];

            if (string.IsNullOrEmpty(urunbilgi.UrunAdi) || string.IsNullOrEmpty(urunbilgi.Kategori) ||
                string.IsNullOrEmpty(urunbilgi.Fiyat) || string.IsNullOrEmpty(urunbilgi.StokAdeti) ||
                string.IsNullOrEmpty(urunbilgi.KayitTarihi))
            {
                errorMessage = "Tüm alanlar zorunludur!";
                return;
            }

            try
            {
                string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=StokTakipDB;Integrated Security=true;TrustServerCertificate=true;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string Sql = "INSERT INTO Urunler (UrunAdi, Kategori, Fiyat, StokAdeti, KayitTarihi) " +
                                 "VALUES (@UrunAdi, @Kategori, @Fiyat, @StokAdeti, @KayitTarihi)";

                    using (SqlCommand command = new SqlCommand(Sql, connection))
                    {
                        command.Parameters.AddWithValue("@UrunAdi", urunbilgi.UrunAdi);
                        command.Parameters.AddWithValue("@Kategori", urunbilgi.Kategori);
                        command.Parameters.AddWithValue("@Fiyat", urunbilgi.Fiyat);
                        command.Parameters.AddWithValue("@StokAdeti", urunbilgi.StokAdeti);

                        // HATA ÇÖZÜMÜ: String gelen tarihi SQL'in anlayacağı DateTime formatına dönüştürüyoruz
                        command.Parameters.AddWithValue("@KayitTarihi", DateTime.Parse(urunbilgi.KayitTarihi));

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            successMessage = "Ürün başarıyla eklendi.";
            Response.Redirect("/UrunYonetimi/Index");
        }
    }
}