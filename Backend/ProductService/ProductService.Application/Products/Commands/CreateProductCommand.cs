using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;


namespace ProductService.Application.Products.Commands
{
    public record CreateProductCommand(
         string Nombre,
         string Descripcion,
         string Categoria,
        byte[] Imagen,
         decimal Precio,
         int Stock
     ) : IRequest<int>;
}
