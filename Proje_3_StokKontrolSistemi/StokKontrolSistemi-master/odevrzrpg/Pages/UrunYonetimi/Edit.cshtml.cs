using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using odevrzrpg.Pages.UrunYonetimi;
using System.Data.SqlClient;

namespace odevrzrpg.Pages.UrunYonetimi
{
    public class EditModel : PageModel
    {
        public Urun urunbilgi = new Urun();
        public string errorMessage = "";
        public string successMessage = "";

        public void OnGet()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=StokTakipDB;Integrated Security=true;TrustServerCertificate=true;";
            string ID = Request.Query["Id"];

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Urunler WHERE Id=@Id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                urunbilgi.Id = reader.GetInt32(0).ToString();
                                urunbilgi.UrunAdi = reader.IsDBNull(1) ? "" : reader.GetString(1);
                                urunbilgi.Kategori = reader.IsDBNull(2) ? "" : reader.GetString(2);
                                urunbilgi.Fiyat = reader.IsDBNull(3) ? "" : reader.GetValue(3).ToString();
                                urunbilgi.StokAdeti = reader.IsDBNull(4) ? "" : reader.GetValue(4).ToString();
                                urunbilgi.KayitTarihi = reader.IsDBNull(5) ? "" : reader.GetDateTime(5).ToString("yyyy-MM-ddTHH:mm"); // HTML input uyumu için format
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
        public void OnPost()
        {
            urunbilgi.Id = Request.Form["Id"];
            urunbilgi.UrunAdi = Request.Form["UrunAdi"];
            urunbilgi.Kategori = Request.Form["Kategori"];
            urunbilgi.Fiyat = Request.Form["Fiyat"];
            urunbilgi.StokAdeti = Request.Form["StokAdeti"];
            urunbilgi.KayitTarihi = Request.Form["KayitTarihi"];

            if (string.IsNullOrEmpty(urunbilgi.UrunAdi) || string.IsNullOrEmpty(urunbilgi.Kategori) ||
                string.IsNullOrEmpty(urunbilgi.Fiyat) || string.IsNullOrEmpty(urunbilgi.StokAdeti) ||
                string.IsNullOrEmpty(urunbilgi.KayitTarihi))
            {
                errorMessage = "Tüm alanlar zorunludur";
                return;
            }

            try
            {
                string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=StokTakipDB;Integrated Security=true;TrustServerCertificate=true;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string Sql = "UPDATE Urunler SET UrunAdi=@UrunAdi, Kategori=@Kategori, Fiyat=@Fiyat, " +
                                 "StokAdeti=@StokAdeti, KayitTarihi=@KayitTarihi WHERE Id=@Id";

                    using (SqlCommand command = new SqlCommand(Sql, connection))
                    {
                        command.Parameters.AddWithValue("@UrunAdi", urunbilgi.UrunAdi);
                        command.Parameters.AddWithValue("@Kategori", urunbilgi.Kategori);
                        command.Parameters.AddWithValue("@Fiyat", urunbilgi.Fiyat);
                        command.Parameters.AddWithValue("@StokAdeti", urunbilgi.StokAdeti);

                        // HATA ÇÖZÜMÜ: Düzenleme sayfasındaki tarih dönüşümü
                        command.Parameters.AddWithValue("@KayitTarihi", DateTime.Parse(urunbilgi.KayitTarihi));
                        command.Parameters.AddWithValue("@Id", urunbilgi.Id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            successMessage = "Ürün başarıyla güncellendi.";
            Response.Redirect("/UrunYonetimi/Index");
        }
    }
}