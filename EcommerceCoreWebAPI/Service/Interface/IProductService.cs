using EcommerceCoreWebAPI.DTOs;
using EcommerceCoreWebAPI.Models;

namespace EcommerceCoreWebAPI.Service.Interface
{
    public interface IProductService
    {
        Task<ProductDto?> GetByIdAsync(int productId);
        Task<List<ProductDto>> GetAllAsync();
        Task AddAsync(ProductDto productDto);
        Task<bool> UpdateProductAsync(ProductDto productDto);
    }
}
