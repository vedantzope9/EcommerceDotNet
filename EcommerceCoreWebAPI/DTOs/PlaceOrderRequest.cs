namespace EcommerceCoreWebAPI.DTOs
{
    public class PlaceOrderRequest
    {
        public string CustomerName { get; set; }
        public List<OrderItemRequest> Items { get; set; }
    }
}
