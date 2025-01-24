using Microsoft.AspNetCore.Mvc;
using LegacyAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace LegacyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private static List<Order> Orders = new List<Order>
        {
            new Order { OrderID = 1, CustomerID = 1, ProductID = 1, Quantity = 2, TotalPrice = 200.00m, OrderDate = DateTime.Now },
            new Order { OrderID = 2, CustomerID = 2, ProductID = 2, Quantity = 1, TotalPrice = 150.00m, OrderDate = DateTime.Now }
        };

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(Orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = Orders.FirstOrDefault(o => o.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order newOrder)
        {
            newOrder.OrderID = Orders.Count + 1;
            Orders.Add(newOrder);
            return CreatedAtAction(nameof(GetOrderById), new { id = newOrder.OrderID }, newOrder);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] Order updatedOrder)
        {
            var order = Orders.FirstOrDefault(o => o.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }
            order.CustomerID = updatedOrder.CustomerID;
            order.ProductID = updatedOrder.ProductID;
            order.Quantity = updatedOrder.Quantity;
            order.TotalPrice = updatedOrder.TotalPrice;
            order.OrderDate = updatedOrder.OrderDate;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = Orders.FirstOrDefault(o => o.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }
            Orders.Remove(order);
            return NoContent();
        }
    }
}
