using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebStore.DAL.Context;
using WebStore.Domain.Entities.Identity;
using WebStore.Domain.Entities.Orders;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels.Products;
using WebStore.ViewModels.Products.Orders;

namespace WebStore.Infrastructure.Services.InSQL
{
    public class SqlOrderDataService : IOrderDataService
    {
        private readonly WebStoreDB db;
        private readonly UserManager<User> userManager;

        public SqlOrderDataService(WebStoreDB db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public async Task<Order> CreateOrder(string userName, CartViewModel cart, OrderViewModel orderModel)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user is null) throw new InvalidOperationException($"User {userName} not exist");

            await using var transaction = await db.Database.BeginTransactionAsync();

            var order = new Order
            {
                Name = orderModel.Name,
                Address = orderModel.Address,
                Phone = orderModel.Phone,
                User = user,
                Date = DateTime.Now,
                Items = new List<OrderItem>()
            };

            foreach (var (product_model, quantity) in cart.Items)
            {
                var product = await db.Products.FindAsync(product_model.Id);
                if (product is null) throw new InvalidOperationException($"Product id:{product_model.Id} not exist");

                var order_item = new OrderItem
                {
                    Order = order,
                    Price = product.Price,
                    Quantity = quantity,
                    Product = product
                };
                order.Items.Add(order_item);
            }

            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();
            await transaction.CommitAsync();

            return order;
        }

        public async Task<IEnumerable<Order>> GetUserOrders(string userName) => await db.Orders
           .Include(order => order.User)
           .Include(order => order.Items)
           .Where(order => order.User.UserName == userName)
           .ToArrayAsync();

        public async Task<Order> GetOrderById(int id) => await db.Orders
           .Include(order => order.Items)
           .FirstOrDefaultAsync(order => order.Id == id);

    }
}
