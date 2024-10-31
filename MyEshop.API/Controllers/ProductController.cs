using Microsoft.AspNetCore.Mvc;
using MyEshop.Application.Services;

namespace MyEshop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllProducts() =>
            Ok(await _productService.GetAllProductsAsync());
    }
}
