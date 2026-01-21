using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ProductService.Application.Products.Commands
{
    public record UpdateProductCommand(
        int Id ,
        string? Description,
        IFormFile? Image,
        decimal? Price,
        int? Stock,
        bool? IsActive
        ):IRequest<bool>;

}
