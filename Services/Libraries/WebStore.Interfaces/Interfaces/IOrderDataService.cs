using System.Collections.Generic;
using System.Threading.Tasks;

using WebStore.Domain.Entities.Orders;
using WebStore.Domain.ViewModels.Products;
using WebStore.Domain.ViewModels.Products.Orders;

namespace WebStore.Interfaces.Interfaces
{
    public interface IOrderDataService
    {
        Task<Order> CreateOrder(string userName, CartViewModel cart, OrderViewModel orderModel);
        Task<IEnumerable<Order>> GetUserOrders(string userName);
        Task<Order> GetOrderById(int id);
    }
}
