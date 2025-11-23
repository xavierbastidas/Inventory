

using Microsoft.AspNetCore.Http;

namespace ProductService.Application.Products.Dtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public IFormFile Image { get; set; }

        public decimal Price { get; set; }

        public int Stock {  get; set; 
        }
        
        
        
    }
}
