using ElectroTrading.Application.UseCase.ProductCompositions.Commands;
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
    public class CompositionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CompositionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "AdminActions")]
        [HttpPost]
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

        [Authorize(Policy = "AdminActions")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProductCompositions(int ProductId, List<int> ids)
        {
            try
            {
                return Ok(await _mediator.Send(new DeleteProductCompositionCommand(ProductId, ids)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
