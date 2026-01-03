namespace EcommerceCoreWebAPI.DTOs
{
    public class OrderItemResponse
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal LineTotal { get; set; }
    }

}
