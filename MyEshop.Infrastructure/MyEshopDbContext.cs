using Microsoft.EntityFrameworkCore;
using MyEshop.Core.Entities;

namespace MyEshop.Infrastructure;

public class MyEshopDbContext : DbContext
{
    public MyEshopDbContext(DbContextOptions<MyEshopDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
            entity.Property(p => p.ImgUri).IsRequired().HasMaxLength(500);
            entity.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(p => p.Description).HasMaxLength(500);
            
            entity.HasData(
                new Product { Id = 1, Name = "Product 01", ImgUri = "www.images.com/product01", Description = "Description for Product 01", Price = 10.99m },
                new Product { Id = 2, Name = "Product 02", ImgUri = "www.images.com/product02", Description = "Description for Product 02", Price = 19.99m },
                new Product { Id = 3, Name = "Product 03", ImgUri = "www.images.com/product03", Price = 29.99m },
                new Product { Id = 4, Name = "Product 04", ImgUri = "www.images.com/product04", Price = 24.99m },
                new Product { Id = 5, Name = "Product 05", ImgUri = "www.images.com/product05", Price = 25.99m },
                new Product { Id = 6, Name = "Product 06", ImgUri = "www.images.com/product06", Price = 26.99m },
                new Product { Id = 7, Name = "Product 07", ImgUri = "www.images.com/product07", Price = 27.99m },
                new Product { Id = 8, Name = "Product 08", ImgUri = "www.images.com/product08", Price = 28.99m },
                new Product { Id = 9, Name = "Product 09", ImgUri = "www.images.com/product09", Price = 29.99m },
                new Product { Id = 10, Name = "Product 10", ImgUri = "www.images.com/product10", Price = 10.99m },
                new Product { Id = 11, Name = "Product 11", ImgUri = "www.images.com/product11", Price = 11.99m },
                new Product { Id = 12, Name = "Product 12", ImgUri = "www.images.com/product12", Price = 12.99m },
                new Product { Id = 13, Name = "Product 13", ImgUri = "www.images.com/product13", Price = 13.99m },
                new Product { Id = 14, Name = "Product 14", ImgUri = "www.images.com/product14", Price = 14.99m },
                new Product { Id = 15, Name = "Product 15", ImgUri = "www.images.com/product15", Price = 15.99m }
            );
        });
    }
}