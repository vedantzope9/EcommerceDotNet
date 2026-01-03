namespace EcommerceCoreWebAPI.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public bool? IsActive { get; set; }
    }
}
