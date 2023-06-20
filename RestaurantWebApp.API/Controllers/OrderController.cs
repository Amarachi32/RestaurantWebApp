
using Contracts.DTOs;
using Contracts.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Interfaces;

namespace RestaurantWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(
            IOrderService orderService
          )
        {
            _orderService = orderService;
        }

        [HttpPost("AddOrder")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> AddOrder(double gst, double priceExclGst, double discount, [FromBody] ShoppingCart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(await _orderService.AddOrder(cart, gst, priceExclGst, discount));
        }

        [HttpPost("UpdateOrder")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> UpdateOrder([FromBody] Order order)
        {
            return Ok(await _orderService.UpdateOrder(order));
        }

        [HttpGet("GetOrdersWithShoppingItems")]
        [ProducesResponseType(typeof(Order), 200)]
        public async Task<IActionResult> GetOrdersWithShoppingItems(int orderId)
        {
            var result = await _orderService.GetOrdersWithShoppingItems(orderId);
            return Ok(result);
        }

        [HttpGet("GetOrdersByUserID")]
        [ProducesResponseType(typeof(List<Order>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> GetOrdersByUserID(string userId, string dateFrom, string dateTo)
        {
            try
            {
                List<Order> results = new List<Order>();

                if (!string.IsNullOrWhiteSpace(userId))
                {
                    int id = int.Parse(userId);
                    results = await _orderService.GetOrdersByUserID(id, dateFrom, dateTo);
                }
                else
                {
                    results = await _orderService.GetOrdersByDate(dateFrom, dateTo);
                }


                return Ok(results);
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse { Status = "false", Message = ex.Message });
            }
        }

        [HttpGet("DeleteOrder")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            var result = await _orderService.DeleteOrder(orderId);
            return Ok(result);
        }
    }
}
