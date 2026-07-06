using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace odevrzrpg.Pages.Satislar
{
    public class DeleteModel : PageModel
    {
        public void OnGet()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=StokTakipDB;Integrated Security=true;TrustServerCertificate=true;";
            string ID = Request.Query["Id"];

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM Satislar WHERE Id=@Id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception) { }

            Response.Redirect("/Satislar/Index");
        }
    }
}