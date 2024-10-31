using MyEshop.Core.Entities;
using MyEshop.Core.Interfaces;

namespace MyEshop.TestUtilities.Mocks;

public class MockProductRepository : IProductRepository
{
    private List<Product> _products;
    public MockProductRepository()
    {
        _products = MockProducts.Products;
    }
    
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return _products;
    }

    public async Task<IEnumerable<Product>> GetProductsPagedAsync(int page, int pageSize)
    {
        return _products.Skip((page - 1) * pageSize)
            .Take(pageSize);
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return _products.FirstOrDefault(x => x.Id == id);
    }

    public async Task UpdateProductDescriptionAsync(int id, string? description)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Id == id);
        if (existingProduct != null)
        {
            existingProduct.Description = description;
        }
    }
}