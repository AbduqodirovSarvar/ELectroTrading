using ElectroTrading.Application.UseCase.Products.Commands;
using ElectroTrading.Application.UseCase.Products.Queries;
using ElectroTrading.Application.UseCase.Salary.Commands;
using ElectroTrading.Application.UseCase.Salary.Queries;
using MediatR;
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

        [HttpPost("Finished")]
        public async Task<IActionResult> CreateFinishedProduct([FromBody] CreateFinishedProductCommand command)
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

        [HttpPost("ProductComposition")]
        public async Task<IActionResult> CreateProductComposition([FromBody] CreateProductCompositionCommand command)
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

        [HttpDelete("ProductComposition")]
        public async Task<IActionResult> DeleteProductCompositions(DeleteProductCompositionCommand command)
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

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteDebt(int Id)
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
        public async Task<IActionResult> GetSalary([FromRoute] int Id)
        {
            return Ok(await _mediator.Send(new GetProductQuery(Id)));
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllSalaryByFilter([FromQuery] GetAllProductByFilterQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
