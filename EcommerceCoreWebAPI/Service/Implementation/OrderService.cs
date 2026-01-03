using EcommerceCoreWebAPI.DTOs;
using EcommerceCoreWebAPI.Models;
using EcommerceCoreWebAPI.Repository.Interface;
using EcommerceCoreWebAPI.Service.Interface;

namespace EcommerceCoreWebAPI.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;

        public OrderService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
        }

        public async Task<List<OrderResponse>> GetAllOrdersAsync()
        {
            var orders = await orderRepository.GetAllAsync();

            List<OrderResponse> list = new List<OrderResponse>();

            foreach (var order in orders)
            {
                var response = new OrderResponse
                {
                    OrderId = order.OrderId,
                    CustomerName=order.CustomerName,
                    Status = order.Status,
                    TotalAmount = order.TotalAmount,
                    Items = order.orderitems.Select(item => new OrderItemResponse
                    {
                        ProductId = (int)item.ProductId,
                        Quantity = item.Quantity,
                        LineTotal = item.LineTotal
                    }).ToList()
                };

                list.Add(response);
            }

            return list;

        }

        public async Task<OrderResponse> PlaceOrderAsync(PlaceOrderRequest request)
        {
            if (request.Items == null || !request.Items.Any())
                throw new ApplicationException("Order must contain at least one item");

            var order = new Order
            {
                CustomerName = request.CustomerName,
                Status = "Placed",
                OrderDate = DateTime.UtcNow,
                orderitems=new List<OrderItem>()
            };

            decimal total = 0;

            foreach(var item in request.Items)
            {
                var product = await productRepository.GetByIdAsync(item.ProductId);

                if (product == null)
                    throw new KeyNotFoundException($"Product {item.ProductId} not found");


                decimal lineTotal = product.Price * item.Quantity;

                order.orderitems.Add(new OrderItem
                {
                    OrderId = order.OrderId,
                    ProductId = product.ProductId,
                    Quantity = item.Quantity,
                    LineTotal = lineTotal
                });
                total += lineTotal;
            }
            order.TotalAmount = total;
            await orderRepository.AddAsync(order);
            await orderRepository.SaveChangesAsync();

            return new OrderResponse
            {
                OrderId=order.OrderId,
                CustomerName=order.CustomerName,
                TotalAmount=order.TotalAmount,
                Status=order.Status,
                Items = order.orderitems.Select(i => new OrderItemResponse
                {
                    ProductId = (int)i.ProductId,
                    Quantity = i.Quantity,
                    LineTotal = i.LineTotal

                }).ToList()
            };
        }

        public async Task CancelOrderAsync(int orderId)
        {
            var order = await orderRepository.GetByIdAsync(orderId);

            if (order == null)
                throw new KeyNotFoundException("Order not found");

            if (order.Status != "Placed")
                throw new ApplicationException("Only placed orders can be cancelled");

            order.Status = "Cancelled";
            await orderRepository.SaveChangesAsync();
        }

        public async Task<OrderResponse> GetOrderAsync(int orderId)
        {
            var order = await orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new KeyNotFoundException("Order not found");

            return new OrderResponse
            {
                OrderId = order.OrderId,
                CustomerName=order.CustomerName,
                Status = order.Status,
                TotalAmount = order.TotalAmount,
                Items = order.orderitems.Select(i => new OrderItemResponse
                {
                    ProductId = (int)i.ProductId,
                    Quantity = i.Quantity,
                    LineTotal=i.LineTotal

                }).ToList()
            };
        }
    }
}
