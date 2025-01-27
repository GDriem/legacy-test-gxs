using Legacy_api.Models.OrdersModel;
using Legacy_api.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Legacy_api.Application.Orders
{
    public interface IOrdersApplication
    {
        //public List<Order> AddOrders();
        public IEnumerable<Order> getOrders();
        public Order? getOrderById(int id);
        public Task addOrder(Order newOrder);
        public Task<bool> deleteOrder(int id);
        public Task<JsonResponse> updateOrder(int id, Order updatedOrder);
    }
}
