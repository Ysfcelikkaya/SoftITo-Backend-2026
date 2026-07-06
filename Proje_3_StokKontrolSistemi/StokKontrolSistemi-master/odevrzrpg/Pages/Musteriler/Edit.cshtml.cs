using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace odevrzrpg.Pages.Musteriler
{
    public class EditModel : PageModel
    {
        public Musteri musteribilgi = new Musteri();
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
                    string sql = "SELECT * FROM Musteriler WHERE Id=@Id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                musteribilgi.Id = reader.GetInt32(0).ToString();
                                musteribilgi.AdSoyad = reader.IsDBNull(1) ? "" : reader.GetString(1);
                                musteribilgi.Telefon = reader.IsDBNull(2) ? "" : reader.GetString(2);
                                musteribilgi.Eposta = reader.IsDBNull(3) ? "" : reader.GetString(3);
                                musteribilgi.Sehir = reader.IsDBNull(4) ? "" : reader.GetString(4);
                                musteribilgi.Bakiye = reader.IsDBNull(5) ? "0" : reader.GetValue(5).ToString();
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
            musteribilgi.Id = Request.Form["Id"];
            musteribilgi.AdSoyad = Request.Form["AdSoyad"];
            musteribilgi.Telefon = Request.Form["Telefon"];
            musteribilgi.Eposta = Request.Form["Eposta"];
            musteribilgi.Sehir = Request.Form["Sehir"];
            musteribilgi.Bakiye = Request.Form["Bakiye"];

            if (string.IsNullOrEmpty(musteribilgi.AdSoyad) || string.IsNullOrEmpty(musteribilgi.Telefon) ||
                string.IsNullOrEmpty(musteribilgi.Eposta) || string.IsNullOrEmpty(musteribilgi.Sehir) ||
                string.IsNullOrEmpty(musteribilgi.Bakiye))
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
                    string Sql = "UPDATE Musteriler SET AdSoyad=@AdSoyad, Telefon=@Telefon, Eposta=@Eposta, " +
                                 "Sehir=@Sehir, Bakiye=@Bakiye WHERE Id=@Id";

                    using (SqlCommand command = new SqlCommand(Sql, connection))
                    {
                        command.Parameters.AddWithValue("@AdSoyad", musteribilgi.AdSoyad);
                        command.Parameters.AddWithValue("@Telefon", musteribilgi.Telefon);
                        command.Parameters.AddWithValue("@Eposta", musteribilgi.Eposta);
                        command.Parameters.AddWithValue("@Sehir", musteribilgi.Sehir);
                        command.Parameters.AddWithValue("@Bakiye", musteribilgi.Bakiye);
                        command.Parameters.AddWithValue("@Id", musteribilgi.Id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            successMessage = "Müşteri bilgileri başarıyla güncellendi.";
            Response.Redirect("/Musteriler/Index");
        }
    }
}