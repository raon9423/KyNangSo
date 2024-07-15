using System;
using WebAppCore.Models;
using WebAppCore.ModelViews;

namespace WebAppCore.Services
{
    public class OrderService
    {
        public interface IOrderService
        {
            Task<Order> PlaceOrder(Order order);
        }
    }
}

