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
        });
    }
}