using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IDbContextFactory<OrderManagementContext> _contextFactory;

        public CustomerService(IDbContextFactory<OrderManagementContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IQueryable<Customer> GetCustomersAndOrders()
        {
            var context = _contextFactory.CreateDbContext();

            context.Database.EnsureCreated();

            return context.Customers
                .Where(c=> !c.IsDeleted)
                .Include(x=> x.Orders)
                .Include(x=> x.Address);
        }
    }
}
