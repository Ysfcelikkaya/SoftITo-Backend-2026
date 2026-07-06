namespace DbFirstProject.Models
{
    public class SearchView
    {
        public string Query { get; set; }

        public List<Hasta> Hastas { get; set; }
        public List<Doktor> Doktors { get; set; }
        public List<Randevu> Randevus { get; set; }
    }
}
