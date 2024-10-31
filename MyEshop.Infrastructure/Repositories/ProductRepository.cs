using Microsoft.EntityFrameworkCore;
using MyEshop.Core.Entities;
using MyEshop.Core.Interfaces;

namespace MyEshop.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly MyEshopDbContext _context;

    public ProductRepository(MyEshopDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsPagedAsync(int page, int pageSize)
    {
        return await _context.Products
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task UpdateProductDescriptionAsync(int id, string description)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            product.Description = description;
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}