namespace DapperECommerce.Models
{
    public class OrderReport
    {
        public int OrderId { get; set; }
        public string FullName { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}