using MediatR;
using ProductService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
}
    


    

