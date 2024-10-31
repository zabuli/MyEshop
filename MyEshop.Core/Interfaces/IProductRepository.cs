using MyEshop.Core.Entities;

namespace MyEshop.Core.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<IEnumerable<Product>> GetProductsPagedAsync(int page, int pageSize);
    Task<Product?> GetProductByIdAsync(int id);
    Task UpdateProductDescriptionAsync(int id, string description);
}