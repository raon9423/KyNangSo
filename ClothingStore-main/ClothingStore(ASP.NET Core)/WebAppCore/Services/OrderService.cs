using static WebAppCore.Services.OrderService;
using WebAppCore.Models;
using WebAppCore.Repositories;

namespace StockAppWebApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<List<Order>> GetOrderHistory()
        {
            throw new NotImplementedException();
        }

        public Task<Order> PlaceOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}