using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyEshop.API.Dtos;
using MyEshop.Application.Services;

namespace MyEshop.API.Controllers
{
    /// <summary>
    /// Product Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ProductService _productService;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mapper">Automapper</param>
        /// <param name="productService">Product Service</param>
        public ProductController(IMapper mapper, ProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }
        
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>Products</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productDtos);   
        }
        
        /// <summary>
        /// Retrieves a product by ID.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <returns>The requested product.</returns>
        /// <response code="200">Returns the product if found.</response>
        /// <response code="404">Returns if the product is not found.</response>
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
        
        /// <summary>
        /// Updates the description of a product by ID.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <param name="newDescription">The new description for the product.</param>
        /// <returns>No content if successful.</returns>
        /// <response code="204">Returns no content if the update is successful.</response>
        /// <response code="404">Returns if the product is not found.</response>
        /// <response code="500">Returns an internal server error if an exception occurs.</response>
        [HttpPut("{id}/description")]
        public async Task<IActionResult> UpdateProductDescription(int id, [FromBody] string? newDescription)
        {
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
