using ElectroTrading.Application.UseCase.Salary.Commands;
using ElectroTrading.Application.UseCase.Salary.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectroTrading.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDebtController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeDebtController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDebt([FromBody] CreateDebtCommand command)
        {
            try
            {
                return Ok(await (_mediator.Send(command)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{DebtId}")]
        public async Task<IActionResult> GetDebt([FromRoute] int DebtId)
        {
            try
            {
                return Ok(await _mediator.Send(new GetDebtQuery(DebtId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllDebtByFilter([FromQuery] GetAllDebtByFilterQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateDebt([FromBody] UpdateDebtCommand command)
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
                return Ok(await _mediator.Send(new DeleteDebtCommand(Id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
