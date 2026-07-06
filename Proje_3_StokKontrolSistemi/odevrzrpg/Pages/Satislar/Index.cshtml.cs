using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace odevrzrpg.Pages.Satislar
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Satis> listele { get; set; } = new List<Satis>();

        public void OnGet()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=StokTakipDB;Integrated Security=true;TrustServerCertificate=true;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Satislar ORDER BY SatisTarihi DESC";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Satis satis = new Satis
                                {
                                    Id = reader.GetInt32(0).ToString(),
                                    MusteriAdSoyad = reader.IsDBNull(1) ? "" : reader.GetString(1),
                                    UrunAdi = reader.IsDBNull(2) ? "" : reader.GetString(2),
                                    Adet = reader.IsDBNull(3) ? "0" : reader.GetInt32(3).ToString(),
                                    ToplamTutar = reader.IsDBNull(4) ? "0" : reader.GetValue(4).ToString(),
                                    SatisTarihi = reader.IsDBNull(5) ? "" : reader.GetDateTime(5).ToString("dd.MM.yyyy HH:mm")
                                };
                                listele.Add(satis);
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