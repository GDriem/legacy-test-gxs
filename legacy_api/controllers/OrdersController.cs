using Microsoft.AspNetCore.Mvc;
using LegacyAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Legacy_api.Application.Orders;

namespace LegacyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersApplication _orderService;

        public OrdersController(IOrdersApplication orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Retrieves all orders.
        /// </summary>
        /// <returns>The list of orders.</returns>
        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_orderService.getOrders());
        }

        /// <summary>
        /// Retrieves an order by its ID.
        /// </summary>
        /// <param name="id">The ID of the order.</param>
        /// <returns>The order with the specified ID.</returns>
        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var product = _orderService.getOrderById(id);
            if (product == null)
                return NotFound(new { message = "Orden no encontrada" });

            return Ok(product);
        }

        ///// <summary>
        ///// Creates a new order.
        ///// </summary>
        ///// <param name="newOrder">The new order to create.</param>
        ///// <returns>The created order.</returns>
        //[HttpPost]
        //public IActionResult CreateOrder([FromBody] Order newOrder)
        //{
        //    newOrder.OrderID = Orders.Count + 1;
        //    Orders.Add(newOrder);
        //    return CreatedAtAction(nameof(GetOrderById), new { id = newOrder.OrderID }, newOrder);
        //}

        ///// <summary>
        ///// Updates an existing order.
        ///// </summary>
        ///// <param name="id">The ID of the order to update.</param>
        ///// <param name="updatedOrder">The updated order.</param>
        ///// <returns>No content.</returns>
        //[HttpPut("{id}")]
        //public IActionResult UpdateOrder(int id, [FromBody] Order updatedOrder)
        //{
        //    var order = Orders.FirstOrDefault(o => o.OrderID == id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }
        //    order.CustomerID = updatedOrder.CustomerID;
        //    order.ProductID = updatedOrder.ProductID;
        //    order.Quantity = updatedOrder.Quantity;
        //    order.TotalPrice = updatedOrder.TotalPrice;
        //    order.OrderDate = updatedOrder.OrderDate;
        //    return NoContent();
        //}

        ///// <summary>
        ///// Deletes an order.
        ///// </summary>
        ///// <param name="id">The ID of the order to delete.</param>
        ///// <returns>No content.</returns>
        //[HttpDelete("{id}")]
        //public IActionResult DeleteOrder(int id)
        //{
        //    var order = Orders.FirstOrDefault(o => o.OrderID == id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }
        //    Orders.Remove(order);
        //    return NoContent();
        //}
    }
}
