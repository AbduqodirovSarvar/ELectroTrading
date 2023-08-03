using ElectroTrading.Application.UseCase.Photos.Commands;
using ElectroTrading.Application.UseCase.Photos.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectroTrading.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPhotoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductPhotoController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePhoto([FromForm] CreateProductPhotoCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetPhoto([FromRoute] int Id)
        {
            var fileBytes = System.IO.File.ReadAllBytes("C:\\Users\\Sarvar\\OneDrive\\Ishchi stol\\Electro Trading\\ElectroTrading.Api\\Files\\Photos\\IMG_b047040d-8b71-48af-ab87-76592fbfca28.png");

            return Ok(await _mediator.Send(new GetProductPhotoQuery(Id)));
        }
    }
}
