using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Users.Commands;
using ElectroTrading.Application.UseCase.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectroTrading.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator) 
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommand command)
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
        [Route("{EmployeeId}")]
        public async Task<IActionResult> GetEmployee([FromRoute] int EmployeeId)
        {
            try
            {
                return Ok(await _mediator.Send(new GetEmployeeQuery(EmployeeId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int Id)
        {
            try
            {
                return Ok(await _mediator.Send(new DeleteEmployeeCommand(Id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand command)
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

        [HttpGet("All")]
        public async Task<IActionResult> GetAllEmployeeByFilter([FromBody] GetAllEmployeeByFilterQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
