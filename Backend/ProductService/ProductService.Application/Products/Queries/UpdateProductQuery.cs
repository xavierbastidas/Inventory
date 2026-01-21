using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Queries
{
    public record UpdateProductQuery(int Id): IRequest<Boolean>;
   
}

