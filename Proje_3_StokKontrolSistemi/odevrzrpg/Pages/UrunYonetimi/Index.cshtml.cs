using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace odevrzrpg.Pages.UrunYonetimi
{
    public class IndexModel : PageModel
    {

            [BindProperty]
            public List<Urun> listele { get; set; } = new List<Urun>();

            public void OnGet()
            {
                string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=StokTakipDB;Integrated Security=true;TrustServerCertificate=true;";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "SELECT * FROM Urunler";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Urun urun = new Urun
                                    {
                                        Id = reader.GetInt32(0).ToString(),
                                        UrunAdi = reader.IsDBNull(1) ? "" : reader.GetString(1).ToString(),
                                        Kategori = reader.IsDBNull(2) ? "" : reader.GetString(2).ToString(),
                                        Fiyat = reader.IsDBNull(3) ? "" : reader.GetValue(3).ToString(),
                                        StokAdeti = reader.IsDBNull(4) ? "" : reader.GetValue(4).ToString(),
                                        KayitTarihi = reader.IsDBNull(5) ? "" : reader.GetDateTime(5).ToString("dd.MM.yyyy HH:mm")
                                    };
                                    listele.Add(urun);
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
