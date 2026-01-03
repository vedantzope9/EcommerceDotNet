using EcommerceCoreWebAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceCoreWebAPI.Service.Interface
{
    public interface IOrderService
    {
        Task<List<OrderResponse>> GetAllOrdersAsync();
        Task<OrderResponse> PlaceOrderAsync(PlaceOrderRequest request);
        Task<OrderResponse> GetOrderAsync(int orderId);
        Task CancelOrderAsync(int orderId);
    }
}
