using OpenPolytechnic.Business.Model.Order;

namespace OpenPolytechnic.Business.Services.Interfaces
{
    public interface IOrderService
    {
        public OrderSummary GetOrderSummary(Orders orders);
    }
}
