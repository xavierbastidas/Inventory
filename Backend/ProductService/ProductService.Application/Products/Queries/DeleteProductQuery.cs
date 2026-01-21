using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Queries
{
    public record  DeleteProductQuery(int Id) : IRequest<Boolean>;
}
