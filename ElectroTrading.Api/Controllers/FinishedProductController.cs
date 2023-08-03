using ElectroTrading.Application.UseCase.FinishedProducts.Commands;
using ElectroTrading.Application.UseCase.Salary.Commands;
using ElectroTrading.Application.UseCase.Salary.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ElectroTrading.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinishedProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FinishedProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Policy = "AdminActions")]
        [HttpPost]
        public async Task<IActionResult> CreateFinishedProduct([FromBody] CreateFinishedProductCommand command)
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


    }
}
