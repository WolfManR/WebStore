using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading.Tasks;

using WebStore.Domain.DTO.Order;
using WebStore.Interfaces;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [Route(WebApiAddresses.Orders)]
    [ApiController]
    public class OrdersApiController : ControllerBase, IOrderDataService
    {
        private readonly IOrderDataService orderDataService;

        public OrdersApiController(IOrderDataService orderDataService) => this.orderDataService = orderDataService;


        [HttpPost("{userName")]
        public Task<OrderDTO> CreateOrder(string userName,[FromBody] CreateOrderModel orderModel) => orderDataService.CreateOrder(userName, orderModel);

        [HttpGet("user/{userName}")]
        public Task<IEnumerable<OrderDTO>> GetUserOrders(string userName) => orderDataService.GetUserOrders(userName);

        [HttpGet("{id}")]
        public Task<OrderDTO> GetOrderById(int id) => orderDataService.GetOrderById(id);
    }
}
