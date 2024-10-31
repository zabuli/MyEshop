using MyEshop.Core.Entities;
using MyEshop.Core.Interfaces;

namespace MyEshop.Application.Services;

public class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<IEnumerable<Product>> GetAllProductsAsync() =>
        await _productRepository.GetAllProductsAsync();

    public async Task<IEnumerable<Product>> GetProductsPagedAsync(int page, int pageSize) =>
        await _productRepository.GetProductsPagedAsync(page, pageSize);

    public async Task<Product?> GetProductByIdAsync(int id) =>
        await _productRepository.GetProductByIdAsync(id);

    public async Task UpdateProductDescriptionAsync(int id, string description) =>
        await _productRepository.UpdateProductDescriptionAsync(id, description);
}