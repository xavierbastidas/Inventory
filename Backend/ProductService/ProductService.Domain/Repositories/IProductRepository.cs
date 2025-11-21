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
      

    }
}
