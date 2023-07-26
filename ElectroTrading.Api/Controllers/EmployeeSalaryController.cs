using ElectroTrading.Application.UseCase.Salary.Commands;
using ElectroTrading.Application.UseCase.Salary.Queries;
using MediatR;
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

        [HttpPost("Salary")]
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

        [HttpPost("Debt")]
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
        [Route("Salary/{SalaryId}")]
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

        [HttpGet]
        [Route("Debt/{DebtId}")]
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

        [HttpGet("All/Debts")]
        public async Task<IActionResult> GetAllDebtByFilter([FromQuery] GetAllDebtByFilterQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("All/Salaries")]
        public async Task<IActionResult> GetAllSalaryByFilter([FromQuery] GetAllSalaryByFilterQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPatch("Debt")]
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

        [HttpPatch("Salary")]
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

        [HttpDelete("Debt/{Id}")]
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

        [HttpDelete("Salary/{Id}")]
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
