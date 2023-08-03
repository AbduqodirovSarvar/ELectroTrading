using ElectroTrading.Application.UseCase.BSProducts.Commands;
using ElectroTrading.Application.UseCase.BSProducts.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectroTrading.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BSProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BSProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "AdminActions")]
        [HttpPost]
        public async Task<IActionResult> CreateBSProduct([FromBody] CreateBSProductCommand command)
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
        [HttpPatch]
        public async Task<IActionResult> UpdateBSProduct([FromBody] UpdateBSProductCommand command)
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
        public async Task<IActionResult> DeleteBSProduct(int Id)
        {
            try
            {
                return Ok(await _mediator.Send(new DeleteBSProductCommand(Id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetBSProduct(int Id)
        {
            return Ok(await _mediator.Send(new GetBSProductQuery(Id)));
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllBSProductByFilter([FromQuery] GetAllBSProductByFilterQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
