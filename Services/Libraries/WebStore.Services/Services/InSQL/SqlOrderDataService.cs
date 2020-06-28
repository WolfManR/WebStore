using AutoMapper;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebStore.DAL.Context;
using WebStore.Domain.DTO.Order;
using WebStore.Domain.Entities.Identity;
using WebStore.Domain.Entities.Orders;
using WebStore.Interfaces.Services;

namespace WebStore.Services.Services.InSQL
{
    public class SqlOrderDataService : IOrderDataService
    {
        private readonly WebStoreDB db;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public SqlOrderDataService(WebStoreDB db, UserManager<User> userManager, IMapper mapper)
        {
            this.db = db;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<OrderDTO> CreateOrder(string userName, CreateOrderModel orderModel)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user is null) throw new InvalidOperationException($"User {userName} not exist");

            await using var transaction = await db.Database.BeginTransactionAsync();

            var order = new Order
            {
                Name = orderModel.Order.Name,
                Address = orderModel.Order.Address,
                Phone = orderModel.Order.Phone,
                User = user,
                Date = DateTime.Now,
                Items = new List<OrderItem>()
            };

            foreach (var item in orderModel.Items)
            {
                var product = await db.Products.FindAsync(item.Id);
                if (product is null) throw new InvalidOperationException($"Product id:{item.Id} not exist");

                var orderItem = new OrderItem
                {
                    Order = order,
                    Price = product.Price,
                    Quantity = item.Quantity,
                    Product = product
                };
                order.Items.Add(orderItem);
            }

            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();
            await transaction.CommitAsync();

            return mapper.Map<OrderDTO>(order);
        }

        public async Task<IEnumerable<OrderDTO>> GetUserOrders(string userName) => (await db.Orders
           .Include(order => order.User)
           .Include(order => order.Items)
           .Where(order => order.User.UserName == userName)
           .ToArrayAsync())
            .Select(mapper.Map<OrderDTO>);

        public async Task<OrderDTO> GetOrderById(int id) => mapper.Map<OrderDTO>(await db.Orders
           .Include(order => order.Items)
           .FirstOrDefaultAsync(order => order.Id == id));
    }
}
