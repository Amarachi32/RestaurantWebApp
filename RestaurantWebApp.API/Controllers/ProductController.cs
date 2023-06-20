using Contracts.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Interfaces;

namespace RestaurantWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productService;
        public ProductController(IProductServices services)
        {
            _productService = services;
        }


        [HttpGet("GetAllProducts")]
        [ProducesResponseType(typeof(List<Product>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                List<Product> products = new List<Product>();
                products = await _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse { Status = "false", Message = ex.Message });

            }
        }

        [HttpPost("AddProduct")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            return Ok(await _productService.Add(product));
        }

        [HttpPost("UpdateProduct")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            return Ok(await _productService.UpdateProduct(product));
        }

        [HttpPost("UpdatePackagingList")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> UpdatePackagingList(int productId, [FromBody] List<PackagingList> lists)
        {
            return Ok(await _productService.UpdatePackagingList(lists, productId));
        }

        [HttpPost("DeleteProduct")]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<IActionResult> DeleteProduct([FromBody] Product product)
        {
            return Ok(await _productService.DeleteProduct(product));
        }
    }
}
