using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProductService.Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options):base(options){ }
       public DbSet<Product>Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Nombre de la tabla
            modelBuilder.Entity<Product>()
                .ToTable("products");
            // Clave primaria
            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);
            // Mapeo de columnas
            modelBuilder.Entity<Product>().Property(p => p.ProductId).HasColumnName("product_id");
            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnName("name");
            modelBuilder.Entity<Product>().Property(p => p.Description).HasColumnName("description");
            modelBuilder.Entity<Product>().Property(p => p.Category).HasColumnName("category");
            modelBuilder.Entity<Product>().Property(p => p.Image).HasColumnName("image");
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnName("price");
            modelBuilder.Entity<Product>().Property(p => p.Stock).HasColumnName("stock");
            modelBuilder.Entity<Product>().Property(p => p.IsActive).HasColumnName("is_active");
            modelBuilder.Entity<Product>().Property(p => p.CreatedAt).HasColumnName("created_at");
            modelBuilder.Entity<Product>().Property(p => p.UpdatedAt).HasColumnName("updated_at");
        }
    }
}
