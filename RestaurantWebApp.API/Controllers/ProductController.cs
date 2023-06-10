
using Contracts.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Interfaces;

namespace RestaurantWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IServiceManager _service;
        public ProductController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                var product = _service.productService.GetAllProducts(trackChanges: false);
                return Ok(product);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}", Name = "ProductById")]
        public IActionResult GetProduct(int id)
        {
            var product = _service.productService.GetProduct(id, trackChanges: false);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductDto createProduct)
        {
            if(createProduct is null)
            {
                return BadRequest("product cant be null");
            }
            var createdProduct = _service.productService.CreateProduct(createProduct);

            return CreatedAtRoute( "ProductById", new {id =createdProduct.Id}, createdProduct);
        }
        [HttpPut]
        public IActionResult UpdateProduct(int productId, UpdateProductDto updateProduct) 
        {
            _service.productService.UpdateProduct(productId, updateProduct,trackChanges: false);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            _service.productService.DeleteProduct(id, trackChanges: false);
            return NoContent();
        }
    }
}
