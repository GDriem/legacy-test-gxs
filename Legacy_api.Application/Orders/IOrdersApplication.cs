
using LegacyAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Legacy_api.Application.Orders
{
    public interface IOrdersApplication
    {
        //public List<Order> AddOrders();
        public IEnumerable<Order> getOrders();
        public Order? getOrderById(int id);
        public Task<string> addOrder(Order newOrder);
        public Task<bool> deleteOrder(int id);
        public Task<string> updateOrder(Order updatedOrder);
    }
}
