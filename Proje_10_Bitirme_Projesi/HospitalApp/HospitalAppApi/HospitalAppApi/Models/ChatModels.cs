namespace HospitalAppApi.Models
{
    public class ChatRequest
    {
        public string Message { get; set; }
    }

    public class ChatResponse
    {
        public string Reply { get; set; }
        public string RecommendedDepartment { get; set; }
    }
}