using EcommerceCoreWebAPI.DTOs;
using EcommerceCoreWebAPI.Models;
using EcommerceCoreWebAPI.Repository.Interface;
using EcommerceCoreWebAPI.Service.Interface;

namespace EcommerceCoreWebAPI.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository repository)
        {
            productRepository = repository;
        }
        public async Task AddAsync(ProductDto dto)
        {
            var product = new Product
            {
                ProductId=0,
                ProductName = dto.ProductName,
                Price = dto.Price,
                IsActive = dto.IsActive
            };

            await productRepository.AddAsync(product);
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products= await productRepository.GetAllAsync();

            return products.Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Price = p.Price,
                IsActive = p.IsActive
            }).ToList();
        }

        public async Task<ProductDto?> GetByIdAsync(int productId)
        {
            var product= await productRepository.GetByIdAsync(productId);

            if (product == null)
                return null;

            return new ProductDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.Price,
                IsActive = product.IsActive
            };
        }

        public async Task<bool> UpdateProductAsync(ProductDto dto)
        {
            var product = new Product
            {
                ProductId = dto.ProductId,
                ProductName = dto.ProductName,
                Price = dto.Price,
                IsActive = dto.IsActive
            };

            return await productRepository.UpdateProductAsync(product);
        }
    }
}
