using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using WebStore.Clients.Base;
using WebStore.Domain.DTO.Order;
using WebStore.Interfaces;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Orders
{
    public class OrdersClient : BaseClient, IOrderDataService
    {
        public OrdersClient(IConfiguration configuration) : base(configuration, WebApiAddresses.Orders) {}


        public async Task<OrderDTO> CreateOrder(string userName, CreateOrderModel orderModel)
        {
            var response = await PostAsync($"{ServiceAddress}/{userName}", orderModel);
            return await response.Content.ReadAsAsync<OrderDTO>();
        }

        public async Task<IEnumerable<OrderDTO>> GetUserOrders(string userName) => await GetAsync<IEnumerable<OrderDTO>>($"{ServiceAddress}/user/{userName}");

        public async Task<OrderDTO> GetOrderById(int id) => await GetAsync<OrderDTO>($"{ServiceAddress}/{id}");
    }
}