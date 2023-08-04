using ElectroTrading.Application.UseCase.Photos.Commands;
using ElectroTrading.Application.UseCase.Photos.Queries;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace ElectroTrading.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPhotoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _env;
        public ProductPhotoController(IMediator mediator, IWebHostEnvironment env) 
        {
            _mediator = mediator;
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePhoto([FromForm] GettingFile command)
        {
            if(command.Image == null)
            {
                return BadRequest();
            }

            string webRootPath = _env.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(command.Image.FileName);
            string filePath = Path.Combine(webRootPath, "Images", fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await command.Image.CopyToAsync(fileStream);
            }

            var res = await _mediator.Send(new CreateProductPhotoCommand(1, fileName, filePath));
            return Ok(res);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<PhysicalFileResult> GetPhoto([FromRoute] int Id)
        {
            var res = await _mediator.Send(new GetProductPhotoQuery(Id));

            return PhysicalFile(res.Item1, res.Item2);
        }
    }

    public class GettingFile
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public IFormFile? Image { get; set; }
    }
}
