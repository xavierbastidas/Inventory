using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace ProductService.Application.Products.Commands
{
    public record CreateProductCommand(
         string Name,
         string Description,
         string Category,
          IFormFile Image,
         decimal Price,
         int Stock
     ) : IRequest<int>;
}
