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
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IProductService _productService;


        public AdminController(IOrderService orderService, IUserService userService,
            IProductService productService)
        {
            _orderService = orderService;
            _userService = userService;
            _productService = productService;
        }

        [HttpGet("GetUserByAccount")]

        [ProducesResponseType(typeof(User), 200)]
        public async Task<IActionResult> GetUserByAccount(string userId)
        {
            var userInfo = await _userService.GetUserByIdAsync(userId);
            return Ok(userInfo);
        }

        [HttpGet("GetUsers")]
        [ProducesResponseType(typeof(List<User>), 200)]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("DeleteUser")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var result = await _userService.DeleteAsync(userId);
            return Ok(result);
        }

       /* [HttpPost("UpdateUser")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
           // var result = await _userService.Update(user);
           return Ok(result);
        }*/

     /*   [HttpPost("AddUser")]
        [NoCache]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            var result = await _userService.AddUser(user);
            return Ok(result);
        }

        [HttpGet("ValidatePassword")]
        [NoCache]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        public async Task<IActionResult> ValidatePassword(int userId, string password)
        {
            var result = await _userService.ValidatePassword(userId, password);
            return Ok(result);
        }

        [HttpGet("UpdatePassword")]
        [NoCache]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        public async Task<IActionResult> UpdatePassword(int userId, string password)
        {
            var result = await _userService.UpdatePassword(userId, password);
            return Ok(result);
        }*/

    }
}
