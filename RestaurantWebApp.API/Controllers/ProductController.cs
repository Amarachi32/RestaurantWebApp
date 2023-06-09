
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
        public ActionResult GetProducts()
        {
            try
            {
                var product = _service.productService.GetAllProducts(trackChanges: false);
                return Ok(product);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
