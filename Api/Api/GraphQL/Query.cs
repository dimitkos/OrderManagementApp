﻿using Core.Entities;
using Core.Interfaces;
using Core.Models;

namespace Api.GraphQL
{
    public class Query
    {
#warning make the code async await
        [UseFiltering]
        public IQueryable<Customer> GetCustomers([Service] ICustomerService customerService)
        {

            return customerService.GetCustomersAndOrders();
        }

        [UseFiltering]
        public IQueryable<Order> GetOrders([Service] IOrderService orderService)
        {
            return orderService.GetOrders();
        }

        public async Task<Stats> GetStats([Service] ICustomerService customerService)
        {
            return await customerService.GetCustomersAndOrdersStats();
        }
    }
}
