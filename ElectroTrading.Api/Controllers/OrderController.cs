using ElectroTrading.Application.UseCase.Orders.Commands;
using ElectroTrading.Application.UseCase.Orders.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectroTrading.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "AdminActions")]

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
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

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetOrder([FromRoute] int Id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetOrderQuery(Id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllOrderByFilter([FromQuery] GetAllOrderByFilterQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [Authorize(Policy = "AdminActions")]
        [HttpPatch]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [Authorize(Policy = "AdminActions")]
        [HttpDelete("{OrderId}")]
        public async Task<IActionResult> DeleteOrder(int OrderId)
        {
            try
            {
                return Ok(await _mediator.Send(new DeleteOrderCommand(OrderId)));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
