using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDbContextFactory<OrderManagementContext> _contextFactory;

        public OrderService(IDbContextFactory<OrderManagementContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IQueryable<Order> GetOrders()
        {
            var context = _contextFactory.CreateDbContext();

            context.Database.EnsureCreated();

            return context.Orders
                .Where(o => !o.IsDeleted)
                .Include(o => o.Customer);
        }
    }
}
