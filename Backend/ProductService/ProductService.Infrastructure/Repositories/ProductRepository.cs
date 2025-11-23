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

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public  async Task<IEnumerable<Product>> GetAllAsync()
        {
           
             return await _context.Products.ToListAsync();
            
           
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
            
        }

        public Task<Product> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
