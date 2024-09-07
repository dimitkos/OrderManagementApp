using Core.Entities;
using Core.Models;

namespace Core.Interfaces
{
    public interface IOrderService
    {
        IQueryable<Order> GetOrders();

        Task<Order> AddOrUpdateOrderAsync(OrderModel order);
        Task<bool> DeleteOrderAsync(int orderId);
    }
}
