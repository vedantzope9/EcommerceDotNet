namespace EcommerceCoreWebAPI.DTOs
{
    public class OrderResponse
    {
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string CustomerName { get; set; }
        public List<OrderItemResponse> Items { get; set; }
    }

}
