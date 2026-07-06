using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using odevrzrpg.Pages.UrunYonetimi;
using System.Data.SqlClient;

namespace odevrzrpg.Pages.UrunYonetimi
{
    public class DeleteModel : PageModel
    {
        public Urun urunbilgi = new Urun();

        public void OnGet()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=StokTakipDB;Integrated Security=true;TrustServerCertificate=true;";

            string ID = Request.Query["Id"];

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "DELETE FROM Urunler WHERE Id=@Id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
            }

            Response.Redirect("/UrunYonetimi/Index");
        }
    }
}