using ElectroTrading.Application.Models.DTOs;
using ElectroTrading.Application.UseCase.Attendances.Commands;
using ElectroTrading.Application.UseCase.Attendances.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Policy = "AdminActions")]
        [HttpPost]
        public async Task<IActionResult> CreateAttendance([FromBody] List<AttendanceCreateDto> command)
        {
            try
            {
                return Ok(await _mediator.Send(new CreateAttendanceCommand(command)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetAttendance([FromRoute] int Id)
        {
            try
            {
                return Ok(await _mediator.Send(new GetAttendanceQuery(Id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllAttendanceByFilter([FromQuery] GetAllAttendanceByFilterQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [Authorize(Policy = "AdminActions")]
        [HttpPatch]
        public async Task<IActionResult> UpdateAttendance([FromBody] List<UpdateAttendanceDto> command)
        {
            try
            {
                return Ok(await _mediator.Send(new UpdateAttendanceCommand(command)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = "AdminActions")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAttendance([FromBody] List<int> command)
        {
            return Ok(await _mediator.Send(new DeleteAttendanceCommand(command)));
        }
    }
}
