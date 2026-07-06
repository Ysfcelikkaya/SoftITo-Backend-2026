using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace odevrzrpg.Pages.Musteriler
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Musteri> listele { get; set; } = new List<Musteri>();

        public void OnGet()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=StokTakipDB;Integrated Security=true;TrustServerCertificate=true;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Musteriler";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Musteri musteri = new Musteri
                                {
                                    Id = reader.GetInt32(0).ToString(),
                                    AdSoyad = reader.IsDBNull(1) ? "" : reader.GetString(1).ToString(),
                                    Telefon = reader.IsDBNull(2) ? "" : reader.GetString(2).ToString(),
                                    Eposta = reader.IsDBNull(3) ? "" : reader.GetString(3).ToString(),
                                    Sehir = reader.IsDBNull(4) ? "" : reader.GetString(4).ToString(),
                                    Bakiye = reader.IsDBNull(5) ? "0" : reader.GetValue(5).ToString()
                                };
                                listele.Add(musteri);
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}