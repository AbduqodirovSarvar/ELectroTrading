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
    public class EmployeeSalaryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeSalaryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "AdminActions")]
        [HttpPost]
        public async Task<IActionResult> CreateSalary([FromBody] CreateSalaryPaymentCommand command)
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
        [Route("{SalaryId}")]
        public async Task<IActionResult> GetSalary([FromRoute] int SalaryId)
        {
            try
            {
                return Ok(await _mediator.Send(new GetSalaryQuery(SalaryId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllSalaryByFilter([FromQuery] GetAllSalaryByFilterQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateSalary([FromBody] UpdateSalaryCommand command)
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
        public async Task<IActionResult> DeleteSalary(int Id)
        {
            try
            {
                return Ok(await _mediator.Send(new DeleteSalaryCommand(Id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
