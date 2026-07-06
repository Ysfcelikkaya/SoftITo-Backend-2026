namespace DapperECommerce.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public string FullName { get; set; }
        public string ProductName { get; set; }
        public DateTime OrderDate { get; set; }
    }
}