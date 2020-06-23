﻿using System.Collections.Generic;
using System.Threading.Tasks;

using WebStore.Domain.Entities.Orders;
using WebStore.ViewModels.Products;
using WebStore.ViewModels.Products.Orders;

namespace WebStore.Infrastructure.Interfaces
{
    public interface IOrderDataService
    {
        Task<Order> CreateOrder(string userName, CartViewModel cart, OrderViewModel orderModel);
        Task<IEnumerable<Order>> GetUserOrders(string userName);
        Task<Order> GetOrderById(int id);
    }
}