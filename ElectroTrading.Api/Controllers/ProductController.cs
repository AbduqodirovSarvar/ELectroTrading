using ElectroTrading.Application.UseCase.OnSale.Commands;
using ElectroTrading.Application.UseCase.ProductCompositions.Commands;
using ElectroTrading.Application.UseCase.Products.Commands;
using ElectroTrading.Application.UseCase.Products.Queries;
using ElectroTrading.Application.UseCase.Salary.Commands;
using ElectroTrading.Application.UseCase.Salary.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectroTrading.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "AdminActions")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = "AdminActions")]
        [HttpPost("Sale")]
        public async Task<IActionResult> CreateSaleProduct([FromBody] CreateOnSaleCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = "AdminActions")]
        [HttpDelete("Sale/{Id}")]
        public async Task<IActionResult> CreateProduct(int Id)
        {
            try
            {
                return Ok(await _mediator.Send(new DeleteOnSaleCommand(Id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = "AdminActions")]
        [HttpPatch]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = "AdminActions")]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            try
            {
                return Ok(await _mediator.Send(new DeleteProductCommand(Id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int Id)
        {
            return Ok(await _mediator.Send(new GetProductQuery(Id)));
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllProductByFilter([FromQuery] GetAllProductByFilterQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
