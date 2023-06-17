
using Contracts.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(
            IOrderRepository orderRepository
          )
        {
            _orderRepository = orderRepository;
        }

        [HttpPost("AddOrder")]
        [NoCache]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> AddOrder(double gst, double priceExclGst, double discount, [FromBody] ShoppingCart cart)
        {
            return Ok(await _orderRepository.AddOrder(cart, gst, priceExclGst, discount));
        }

        [HttpPost("UpdateOrder")]
        [NoCache]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> UpdateOrder([FromBody] Order order)
        {
            return Ok(await _orderRepository.UpdateOrder(order));
        }

        [HttpGet("GetOrdersWithShoppingItems")]
        [NoCache]
        [ProducesResponseType(typeof(Order), 200)]
        public async Task<IActionResult> GetOrdersWithShoppingItems(int orderId)
        {
            var result = await _orderRepository.GetOrdersWithShoppingItems(orderId);
            return Ok(result);
        }

        [HttpGet("GetOrdersByUserID")]
        [NoCache]
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
                    results = await _orderRepository.GetOrdersByUserID(id, dateFrom, dateTo);
                }
                else
                {
                    results = await _orderRepository.GetOrdersByDate(dateFrom, dateTo);
                }


                return Ok(results);
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse { Status = "false", Message = ex.Message });
            }
        }

        [HttpGet("DeleteOrder")]
        [NoCache]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            var result = await _orderRepository.DeleteOrder(orderId);
            return Ok(result);
        }
    }
}
