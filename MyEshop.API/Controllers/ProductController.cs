using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyEshop.API.Dtos;
using MyEshop.Application.Services;

namespace MyEshop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ProductService _productService;

        public ProductController(IMapper mapper, ProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productDtos);   
        }
    }
}
