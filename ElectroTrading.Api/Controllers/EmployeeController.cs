using ElectroTrading.Application.Models.ViewModels;
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

       /* [HttpPost("Create")]
        public async Task<EmployeeViewModel> CreateEmployee([FromBody] int createDto)
        {
            var result = await _mediator.Send(createDto);
            return result;
        }

        [HttpPatch("Update")]
        public async Task<EmployeeViewModel> UpdateEmployee(int updateDto)
        {
            var result = await _mediator.Send(updateDto);
            return result;
        }
        [HttpDelete("{Id}")]
        public async Task<EmployeeViewModel> DeleteEmployee(int Id)
        {
            var result = await _mediator.Send(Id);
            return result;
        }
        [HttpGet("All")]
        public async Task<List<EmployeeViewModel>> GetAllEmployees()
        {
            var result = await _mediator.Send(new Object());
            return result;
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetEmployee([FromRoute] int Id)
        {
            try
            {
                var result = await _mediator.Send(new EmployeeGetQuery(Id));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }*/
    }
}
