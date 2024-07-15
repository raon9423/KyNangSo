using System;
using WebAppCore.Models;
using WebAppCore.ModelViews;
using WebAppCore.Repositories;

namespace StockAppWebApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SqlwebchivalryContext _context;
        public OrderRepository(SqlwebchivalryContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrder(OrderViewModel orderViewModel)
        {
            if (orderViewModel == null)
            {
                throw new ArgumentNullException(nameof(orderViewModel));
            }
            var order = new Order
            {

            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
