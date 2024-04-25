using Core.Entities;
using Core.Interfaces;
using Core.Models;

namespace Api.GraphQL
{
    public class Mutation
    {
        public async Task<Customer> AddOrUpdateCustomer([Service] ICustomerService customerService, CustomerModel customer)
        {
            return await customerService.AddOrUpdateCustomerAsync(customer);
        }

        public async Task<Order> AddOrUpdateOrder([Service] IOrderService customerService, OrderModel order)
        {
            return await customerService.AddOrUpdateOrderAsync(order);
        }
    }
}
