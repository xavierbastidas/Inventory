using MediatR;
using ProductService.Application.Products.Queries;
using ProductService.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Handlers
{
    public  class DeleteProductHandler:
        IRequestHandler<DeleteProductQuery,Boolean>
    {
        private readonly IProductRepository _repo;

        public DeleteProductHandler(IProductRepository repo)
        {
            _repo = repo;
        }   
        public async Task<Boolean>Handle(DeleteProductQuery request ,CancellationToken cancellationToken)
        {
          
            return  await _repo.DeleteAsync(request.Id);
           

        }
    }

}
