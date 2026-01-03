using EcommerceCoreWebAPI.Data;
using EcommerceCoreWebAPI.Models;
using EcommerceCoreWebAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace EcommerceCoreWebAPI.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.products.AddAsync(product);
            await SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int productId)
        {
            return await _context.products.FindAsync(productId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            Product? existingProduct = await GetByIdAsync(product.ProductId);

            if (existingProduct == null)
            {
                return false;
            }
            existingProduct.ProductName = product.ProductName;
            existingProduct.Price = product.Price;
            existingProduct.IsActive = product.IsActive;

            await SaveChangesAsync();
            return true;
        }
    }
}
 