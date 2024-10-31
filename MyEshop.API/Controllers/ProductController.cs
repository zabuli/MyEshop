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
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            
            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }
        
        [HttpPut("{id}/description")]
        public async Task<IActionResult> UpdateProductDescription(int id, [FromBody] string newDescription)
        {
            if (string.IsNullOrWhiteSpace(newDescription))
            {
                return BadRequest("Description cannot be empty.");
            }

            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                
                await _productService.UpdateProductDescriptionAsync(id, newDescription);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
