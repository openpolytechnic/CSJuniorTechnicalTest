using Microsoft.AspNetCore.Mvc;
using OpenPolytechnic.Business.Model.Order;
using OpenPolytechnic.Business.Services.Interfaces;

namespace OpenPolytechnic.TechnicalTest.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        [Route("place")]
        public OrderSummary PlaceOrders(Orders orders)
        {
            var result = orderService.GetOrderSummary(orders);
            return result;
        }
    }
}
