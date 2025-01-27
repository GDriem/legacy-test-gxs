using Legacy_api.Models.OrdersModel;
using Legacy_api.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Legacy_api.Application.Orders
{
    /// <summary>
    /// Represents the application layer for managing orders.
    /// </summary>
    public class OrdersApplication : IOrdersApplication
    {
        private static List<Order> _orders = new List<Order>
                {
                    new Order { OrderID = 1, CustomerID = 1, ProductID = 1, Quantity = 2, TotalPrice = 200.00m, OrderDate = DateTime.Now },
                    new Order { OrderID = 2, CustomerID = 2, ProductID = 2, Quantity = 1, TotalPrice = 150.00m, OrderDate = DateTime.Now }
                };

        /// <inheritdoc/>
        public Order getOrderById(int id) => _orders.FirstOrDefault(o => o.OrderID == id);

        /// <inheritdoc/>
        public IEnumerable<Order> getOrders() => _orders.AsEnumerable();

        /// <inheritdoc/>
        public async Task<bool> deleteOrder(int id)
        {
            var order = getOrderById(id);

            if (order != null)
            {
                _orders.Remove(order);
                return true;
            }
            return false;
        }

        /// <inheritdoc/>
        public async Task addOrder(Order newOrder)
        {
            newOrder.OrderID = _orders.Max(p => p.OrderID) + 1;
            _orders.Add(newOrder);
        }

        /// <inheritdoc/>
        public async Task<JsonResponse> updateOrder(int id, Order updateOrder)
        {
            var order = getOrderById(id);

            if (order == null)
                return new JsonResponse
                {
                    Success = false,
                    StatusCode = 404,
                    Message = $"order with ID {id} not found.",
                    Data = null
                };


            order.CustomerID = updateOrder.CustomerID;
            order.ProductID = updateOrder.ProductID;
            order.Quantity = updateOrder.Quantity;
            order.TotalPrice = updateOrder.TotalPrice;
            order.OrderDate = updateOrder.OrderDate;



            return new JsonResponse
            {
                Success = true,
                Message = "order updated successfully."
            };
        }
    }
}
