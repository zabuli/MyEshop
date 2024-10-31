using AutoMapper;
using DeepEqual.Syntax;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MyEshop.API.Controllers;
using MyEshop.API.Dtos;
using MyEshop.Application.Services;
using MyEshop.Core.Entities;
using MyEshop.Core.Interfaces;

namespace MyEshop.Tests;

public class ProductControllerTests
{
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IProductRepository> _mockProductRepository;
    private readonly ProductController _controller;

    public ProductControllerTests()
    {
        _mockProductRepository = new Mock<IProductRepository>();
        _mockMapper = new Mock<IMapper>();
        var productService = new ProductService(_mockProductRepository.Object);
        _controller = new ProductController(_mockMapper.Object, productService);
    }
    
    [Fact]
    public async Task GetProductById_ReturnsProduct_WhenProductExists()
    {
        var mockProduct = new Product { Id = 1, Name = "Product 01", ImgUri = "www.images.com/product01", Description = "Description for Product 01", Price = 10.99m };
        var mockProductDto = new ProductDto { Id = 1, Name = "Product 01", ImgUri = "www.images.com/product01", Description = "Description for Product 01", Price = 10.99m };

        _mockProductRepository.Setup(x => x.GetProductByIdAsync(mockProduct.Id))
            .ReturnsAsync(mockProduct);
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
        const int productId = 5;
        
        _mockProductRepository.Setup(x => x.GetProductByIdAsync(productId))
            .ReturnsAsync((Product?)null);
        
        var result = await _controller.GetProductById(productId);
        
        Assert.IsType<NotFoundResult>(result);
    }
    
    [Fact]
    public async Task UpdateProductDescription_UpdatesDescription_WhenCalled()
    {
        const int productId = 1;
        const string newDescription = "Updated Description";
        var mockProduct = new Product { Id = 1, Name = "Product 01", ImgUri = "www.images.com/product01", Description = "Description for Product 01", Price = 10.99m };

        _mockProductRepository.Setup(x => x.GetProductByIdAsync(productId))
            .ReturnsAsync(mockProduct);
        _mockProductRepository.Setup(x => x.UpdateProductDescriptionAsync(productId, newDescription))
            .Returns(Task.CompletedTask);
        
        var result = await _controller.UpdateProductDescription(productId, newDescription);
        
        Assert.IsType<NoContentResult>(result);
    }
}