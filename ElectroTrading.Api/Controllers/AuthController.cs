using ElectroTrading.Application.Models.ViewModels;
using ElectroTrading.Application.UseCase.Authorizes.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectroTrading.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<LoginViewModel> Login([FromBody] LoginCommand command)
        {
            try
            {
                LoginViewModel result = await _mediator.Send(command);
                return result;
            }
            catch
            {
                return new LoginViewModel { Status = System.Net.HttpStatusCode.NotFound };
            }
        }
    }
}
