using MediatR;
using ProductService.Application.Products.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ProductService.Domain.Entities;
using ProductService.Domain.Repositories;

namespace ProductService.Application.Products.Handlers
{
    public  class CreateProductHandler : IRequestHandler<CreateProductCommand,int>
    {
        private readonly IProductRepository _repo;

        public CreateProductHandler(IProductRepository repo)
        {
            _repo = repo; 
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Nombre,
                Description = request.Descripcion,
                Category = request.Categoria,
                Image = request.Imagen,
                Price = request.Precio,
                Stock = request.Stock,
            };
            //await _repo.GetProductsAsync(product);
            return product.ProductId;

        }

    }
}
