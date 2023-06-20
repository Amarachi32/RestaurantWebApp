using Contracts.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Interfaces;

namespace RestaurantWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet("GetShoppingCart")]
        [ProducesResponseType(typeof(ShoppingCart), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> GetShoppingCart(string userId)
        {
            return Ok(await _shoppingCartService.GetCartWithShoppingItems(userId));
        }

        [HttpGet("GetCartInIdWithShoppingItems")]
        [ProducesResponseType(typeof(ShoppingCart), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> GetCartInIdWithShoppingItems(int shoppingCartId)
        {
            return Ok(await _shoppingCartService.GetCartInIdWithShoppingItems(shoppingCartId));
        }

        [HttpGet("AddShoppingCart")]
       // [NoCache]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> AddShoppingCart(string userId)
        {
            return Ok(await _shoppingCartService.AddShoppingCart(userId));
        }

        [HttpPost("UpdateShoppingCart")]
       // [NoCache]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> UpdateShoppingCart(string userId, [FromBody] ShoppingItem shoppingItem)
        {
            return Ok(await _shoppingCartService.UpdateShoppingCart(userId, shoppingItem));
        }

        [HttpGet("UpdateShoppingCartPaymentMethod")]
       // [NoCache]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> UpdateShoppingCartPaymentMethod(string userId, string selectedPayment)
        {
            return Ok(await _shoppingCartService.UpdateShoppingCartPaymentMethod(userId, selectedPayment));
        }

        [HttpDelete("deleteShoppingItem")]
       // [NoCache]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> deleteShoppingItem(int shoppingItemId)
        {
            return Ok(await _shoppingCartService.deleteShoppingItem(shoppingItemId));
        }
    }
}
