using System.Collections.Generic;
using System.Threading.Tasks;

using WebStore.Domain.DTO.Order;

namespace WebStore.Interfaces.Services
{
    public interface IOrderDataService
    {
        Task<OrderDTO> CreateOrder(string userName, CreateOrderModel orderModel);
        Task<IEnumerable<OrderDTO>> GetUserOrders(string userName);
        Task<OrderDTO> GetOrderById(int id);
    }
}
