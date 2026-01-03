using EcommerceCoreWebAPI.Models;

namespace EcommerceCoreWebAPI.Repository.Interface
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int productId);
        Task<List<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task SaveChangesAsync();
    }
}
