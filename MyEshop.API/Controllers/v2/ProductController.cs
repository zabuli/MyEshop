using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyEshop.API.Dtos;
using MyEshop.Application.Services;

namespace MyEshop.API.Controllers.v2;

/// <summary>
/// Product Controller
/// </summary>
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
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
    /// <response code="200">Returns all products with pager rules</response>
    [HttpGet]
    [MapToApiVersion("2.0")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProductsV2([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var products = await _productService.GetProductsPagedAsync(pageNumber, pageSize);
        var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
        return Ok(productDtos);   
    }
}