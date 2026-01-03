using EcommerceCoreWebAPI.DTOs;
using EcommerceCoreWebAPI.Models;
using EcommerceCoreWebAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService service)
        {
            productService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductbyId(int id)
        {
            var product = await productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]ProductDto productDto)
        {
            await productService.AddAsync(productDto);
            return Ok("Product added successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync(ProductDto productDto)
        {
            bool res = await productService.UpdateProductAsync(productDto);
            if (!res)
                return NotFound();

            return Ok("Product updated successfully.");
        }
    }
}
