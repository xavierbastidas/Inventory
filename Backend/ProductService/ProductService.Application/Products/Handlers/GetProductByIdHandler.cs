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
    public  class GetProductByIdHandler:
        IRequestHandler<GetProductByIdQuery,Product>
    {
        private readonly IProductRepository _repo;

        public GetProductByIdHandler(IProductRepository repo)
        {
            _repo = repo; 
        }

        public async Task<Product>Handle(GetProductByIdQuery request , CancellationToken cancellationToken)
        {
            var product = await _repo.GetByIdAsync(request.Id);
            if (product == null ) {
                throw new NotFoundException("No se encontro el producto",request.Id);
            }

            return product;

        }
    }
}
