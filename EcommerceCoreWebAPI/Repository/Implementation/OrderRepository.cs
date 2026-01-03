using System.Runtime.CompilerServices;
using EcommerceCoreWebAPI.Data;
using EcommerceCoreWebAPI.Models;
using EcommerceCoreWebAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EcommerceCoreWebAPI.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Order order)
        {
            await _context.orders.AddAsync(order);
            await SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.orders
                            .Include(o=>o.orderitems)
                            .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int orderId)
        {
            return await _context.orders
                            .Include(o => o.orderitems)
                            .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
