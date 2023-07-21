using ElectroTrading.Application.UseCase.Attendances.Commands;
using ElectroTrading.Application.UseCase.Attendances.Queries;
using ElectroTrading.Application.UseCase.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectroTrading.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AttendanceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAttendance([FromBody] AttendanceCreateCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new AttendancesGetAllQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("All/Employee/{Id}")]
        public async Task<IActionResult> GetAllAttendances([FromRoute] int Id)
        {
            var result = await _mediator.Send(new EmployeeGetAllAttendancesQuery(Id));
            return Ok(result);
        }

        [HttpPatch("Update/ForEmployee")]
        public async Task<IActionResult> UpdateAttendance([FromBody] AttendanceUpdateCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
