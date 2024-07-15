using System;
using WebAppCore.Models;
using WebAppCore.ModelViews;

namespace WebAppCore.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrder(OrderViewModel orderViewModel);
    }
}

