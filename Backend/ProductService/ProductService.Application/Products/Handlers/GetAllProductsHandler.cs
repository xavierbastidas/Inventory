using MediatR;
using ProductService.Application.Products.Queries;
using ProductService.Domain.Entities;
using ProductService.Domain.Exceptions;
using ProductService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Handlers
{
    public class GetAllProductsHandler:
        IRequestHandler<GetAllProductQuery,IEnumerable<Product>>

    {
        private readonly IProductRepository _repo;
        public  GetAllProductsHandler(IProductRepository repo) 
        { 
            _repo = repo;

        }
        public async Task<IEnumerable<Product>>Handle(GetAllProductQuery request ,  CancellationToken cancellationToken)
        {
            
                var products = await _repo.GetAllAsync();
                if (products == null || !products.Any())
                {
                    throw new NotFoundException("No se encontraron productos.","No records");
                }
                return products;
          
        }


    }
}
