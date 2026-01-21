using MediatR;
using ProductService.Application.Products.Commands;
using ProductService.Application.Products.Queries;
using ProductService.Domain.Entities;
using ProductService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Handlers
{
    public class UpdateProductHandler:IRequestHandler<UpdateProductCommand, Boolean>
    {
        private readonly IProductRepository _repo;

        public UpdateProductHandler(IProductRepository repo)
        {
            _repo = repo;
        }
       public async Task<Boolean>Handle(UpdateProductCommand request,CancellationToken cancellationToken)
        {


            var product = await _repo.GetByIdAsync(request.Id);
            if (product == null)
            {
                return false;
            }
            else
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

                if (request.Description != null)
                    product.Description = request.Description;

                if (imageBytes != null)
                    product.Image = imageBytes;

                if (request.Price.HasValue)
                    product.Price = request.Price.Value;

                if (request.Stock.HasValue)
                    product.Stock = request.Stock.Value;

                if (request.IsActive.HasValue)
                    product.IsActive = request.IsActive.Value;

                product.UpdatedAt = DateTime.UtcNow;


                return  await _repo.UpdateAsync(product);


            }




        }
    }
}
