using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using ProductService.Domain.Entities;
using ProductService.Domain.Repositories;
using ProductService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProductService.Infrastructure.Repositories
{
    public  class ProductRepository : IProductRepository
    {
        private readonly  AppDbContext _context;

         public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async  Task<Product> AddAsync(Product product)
        {

            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return product;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
                
            
           
        }

        public  async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);

                if (product == null)
                {
                    return false;
                }
                else
                {
                    product.IsActive = false;
                    product.UpdatedAt = DateTime.UtcNow;
                    _context.Products.Update(product);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception  )
            {
                return false;
                
            }
        }

        public  async Task<IEnumerable<Product>> GetAllAsync()
        {
           
             return await _context.Products.Where(p => p.IsActive).ToListAsync();
            
           
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
            
        }

        public Task<bool> UpdateAsync(Product product)
        {
            
            try
            {
               _context.Products.Update(product);
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }
    }
}
