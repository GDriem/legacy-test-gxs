using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using Legacy_api.Application.Orders;
using Legacy_api.Models.OrdersModel;
using System.Threading.Tasks;

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

        /// <summary>
        /// Creates a new order.
        /// </summary>
        /// <param name="newOrder">The new order to create.</param>
        /// <returns>The created order.</returns>
        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order newOrder)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _orderService.addOrder(newOrder);
            return CreatedAtAction(nameof(GetOrderById), new { id = newOrder.OrderID }, newOrder);
        }

        ///// <summary>
        ///// Updates an existing order.
        ///// </summary>
        ///// <param name="id">The ID of the order to update.</param>
        ///// <param name="updatedOrder">The updated order.</param>
        ///// <returns>No content.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order updatedOrder)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _orderService.updateOrder(id, updatedOrder);

            if (!result.Success)
                return result.StatusCode == 404
                    ? NotFound(result.Message)
                    : BadRequest(result.Message);

            return Ok(new { Message = result.Message });
        }



        ///// <summary>
        ///// Deletes an order.
        ///// </summary>
        ///// <param name="id">The ID of the order to delete.</param>
        ///// <returns>No content.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            if (await _orderService.deleteOrder(id))
                return Ok(new { Message = "Orden Eliminada con exito" });

            return NotFound(new { message = "Producto no encontrado" });
        }
    }
}
