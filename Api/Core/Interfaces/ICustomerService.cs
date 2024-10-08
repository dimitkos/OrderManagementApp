﻿using Core.Entities;
using Core.Models;

namespace Core.Interfaces
{
    public interface ICustomerService
    {
        IQueryable<Customer> GetCustomersAndOrders();
        Task<Customer> AddOrUpdateCustomerAsync(CustomerModel customer);
        Task<bool> DeleteCustomerAsync(int customerId);
        Task<Stats> GetCustomersAndOrdersStats();
    }
}
