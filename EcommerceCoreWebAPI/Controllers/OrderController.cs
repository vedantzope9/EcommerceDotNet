using EcommerceCoreWebAPI.DTOs;
using EcommerceCoreWebAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService service)
        {
            orderService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var orders= await orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderRequest request)
        {
            var orderId = await orderService.PlaceOrderAsync(request);
            return Ok(new { OrderId = orderId });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await orderService.GetOrderAsync(id);
            return Ok(order);
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            await orderService.CancelOrderAsync(id);
            return NoContent();
        }
    }
}
