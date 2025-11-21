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

        public  async Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                return await _context.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error de base de datos: " + ex.Message, ex);
            }
        }
    }
}
