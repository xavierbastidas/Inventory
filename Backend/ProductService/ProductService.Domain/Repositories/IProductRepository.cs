using ProductService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.Repositories
{
    public  interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product>GetByIdAsync(int id);
        Task<Product>AddAsync(Product product);
        Task<Product>UpdateAsync(Product product);
        Task<bool>DeleteAsync(int id);


    }
}
