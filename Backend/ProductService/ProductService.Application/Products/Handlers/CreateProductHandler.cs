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

            byte[] imageBytes = null;

            if (request.Image != null)
            {
                using (var ms = new MemoryStream())
                {
                    await request.Image.CopyToAsync(ms);
                    imageBytes = ms.ToArray(); 
                }
            }

            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Category = request.Category,
                Image = imageBytes,
                Price = request.Price,
                Stock = request.Stock,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

                var newProduct = await _repo.AddAsync(product);

                return newProduct.ProductId;
           

        }

    }
}
