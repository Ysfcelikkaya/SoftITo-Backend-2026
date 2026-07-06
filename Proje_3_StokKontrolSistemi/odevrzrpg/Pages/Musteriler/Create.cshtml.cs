using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace odevrzrpg.Pages.Musteriler
{
    public class CreateModel : PageModel
    {
        public Musteri musteribilgi = new Musteri();
        public string errorMessage = "";
        public string successMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            musteribilgi.AdSoyad = Request.Form["AdSoyad"];
            musteribilgi.Telefon = Request.Form["Telefon"];
            musteribilgi.Eposta = Request.Form["Eposta"];
            musteribilgi.Sehir = Request.Form["Sehir"];
            musteribilgi.Bakiye = Request.Form["Bakiye"];

            if (string.IsNullOrEmpty(musteribilgi.AdSoyad) || string.IsNullOrEmpty(musteribilgi.Telefon) ||
                string.IsNullOrEmpty(musteribilgi.Eposta) || string.IsNullOrEmpty(musteribilgi.Sehir) ||
                string.IsNullOrEmpty(musteribilgi.Bakiye))
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

                    string Sql = "INSERT INTO Musteriler (AdSoyad, Telefon, Eposta, Sehir, Bakiye) " +
                                 "VALUES (@AdSoyad, @Telefon, @Eposta, @Sehir, @Bakiye)";

                    using (SqlCommand command = new SqlCommand(Sql, connection))
                    {
                        command.Parameters.AddWithValue("@AdSoyad", musteribilgi.AdSoyad);
                        command.Parameters.AddWithValue("@Telefon", musteribilgi.Telefon);
                        command.Parameters.AddWithValue("@Eposta", musteribilgi.Eposta);
                        command.Parameters.AddWithValue("@Sehir", musteribilgi.Sehir);
                        command.Parameters.AddWithValue("@Bakiye", musteribilgi.Bakiye);

                        // EĞER Ürünler sayfasındaysan ve KayitTarihi hatası alıyorsan parametreyi şu şekilde gönder:
                        // command.Parameters.AddWithValue("@KayitTarihi", DateTime.Parse(urunbilgi.KayitTarihi));

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            successMessage = "Müşteri başarıyla kaydedildi.";
            Response.Redirect("/Musteriler/Index");
        }
    }
}