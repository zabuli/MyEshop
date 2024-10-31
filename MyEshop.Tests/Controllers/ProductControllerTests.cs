using AutoMapper;
using DeepEqual.Syntax;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MyEshop.API.Controllers;
using MyEshop.API.Dtos;
using MyEshop.Application.Services;
using MyEshop.Core.Entities;
using MyEshop.Core.Interfaces;
using MyEshop.TestUtilities.Mocks;

namespace MyEshop.Tests.Controllers;

public class ProductControllerTests
{
    private readonly Mock<IMapper> _mockMapper;
    private readonly ProductController _controller;
    private readonly List<Product> _mockProducts;

    public ProductControllerTests()
    {
        IProductRepository mockProductRepository = new MockProductRepository();
        var productService = new ProductService(mockProductRepository);
        _mockProducts = MockProducts.Products;
        _mockMapper = new Mock<IMapper>();
        _controller = new ProductController(_mockMapper.Object, productService);
    }
    
    [Fact]
    public async Task GetProductById_ReturnsProduct_WhenProductExists()
    {
        var mockProduct = _mockProducts[0];
        var mockProductDto = new ProductDto
        {
            Id = mockProduct.Id, Name = mockProduct.Name, ImgUri = mockProduct.ImgUri, Price = mockProduct.Price,
            Description = mockProduct.Description
        };
        
        _mockMapper.Setup(mapper => mapper.Map<ProductDto>(mockProduct))
            .Returns(mockProductDto);
        
        var result = await _controller.GetProductById(mockProduct.Id); 
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedProductDto = Assert.IsType<ProductDto>(okResult.Value);

        Assert.IsType<OkObjectResult>(result);
        Assert.True(mockProductDto.IsDeepEqual(returnedProductDto));
    }
    
    [Fact]
    public async Task GetProductById_ReturnsNotFound_WhenProductDoesNotExist()
    {
        const int productId = 55;
        
        var result = await _controller.GetProductById(productId);
        
        Assert.IsType<NotFoundResult>(result);
    }
    
    [Fact]
    public async Task UpdateProductDescription_UpdatesDescription_WhenCalled()
    {
        const int productId = 1;
        const string newDescription = "Updated Description";

        var result = await _controller.UpdateProductDescription(productId, newDescription);
        
        Assert.IsType<NoContentResult>(result);
    }
}