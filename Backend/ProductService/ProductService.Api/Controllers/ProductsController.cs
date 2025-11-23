using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Products.Commands;
using ProductService.Application.Products.Dtos;
using ProductService.Application.Products.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           
                var result = await _mediator.Send(new GetAllProductQuery());
                return Ok(result);
           
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromForm] CreateProductDto dto)
        {
            var id = await _mediator.Send(new CreateProductCommand(
                dto.Name,
                dto.Description,
                dto.Category,
                dto.Image,
                dto.Price,
                dto.Stock
                ));

            return CreatedAtAction(nameof(GetById), new { id }, new { id });
             
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product); 
        }
    }
}
