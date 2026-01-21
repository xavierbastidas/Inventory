using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Dtos
{
    public  class UpdateProductDto
    {
      
        public string? Description { get; set; }

        public IFormFile? Image { get; set; }

        public decimal? Price { get; set; }

        public int? Stock { get; set; }

        public bool? IsActive { get; set; }
    }
}
