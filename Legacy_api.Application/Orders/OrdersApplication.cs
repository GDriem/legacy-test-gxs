using LegacyAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Legacy_api.Application.Orders
{
    public class OrdersApplication : IOrdersApplication
    {
            private static List<Order> Orders = new List<Order>
        {
            new Order { OrderID = 1, CustomerID = 1, ProductID = 1, Quantity = 2, TotalPrice = 200.00m, OrderDate = DateTime.Now },
            new Order { OrderID = 2, CustomerID = 2, ProductID = 2, Quantity = 1, TotalPrice = 150.00m, OrderDate = DateTime.Now }
        };

        Order IOrdersApplication.getOrderById(int id) => Orders.FirstOrDefault(o => o.OrderID == id);
        IEnumerable<Order> IOrdersApplication.getOrders() => Orders.AsEnumerable();
        Task<string> IOrdersApplication.addOrder(Order newOrder)
        {
            throw new NotImplementedException();
        }

        Task<bool> IOrdersApplication.deleteOrder(int id)
        {
            throw new NotImplementedException();
        }




        Task<string> IOrdersApplication.updateOrder(Order updateOrder)
        {
            throw new NotImplementedException();
        }
    }
}
