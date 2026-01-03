using EcommerceCoreWebAPI.Models;

namespace EcommerceCoreWebAPI.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(int orderId);
        Task<List<Order>> GetAllAsync();
        Task AddAsync(Order order);
        Task SaveChangesAsync();
    }
}
