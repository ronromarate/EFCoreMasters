using InventoryAppEFCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAppEFCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _service.GetProducts();
            return Ok(result);
        }
    }
}
