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

            try
            {
                string webRootPath = _env.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(command.Image.FileName);
                string filePath = Path.Combine(webRootPath, "Images", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await command.Image.CopyToAsync(fileStream);
                }

                return Ok(await _mediator.Send(new CreateProductPhotoCommand(command.ProductId, fileName, filePath)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePhoto([FromForm] GettingFile command)
        {
            if(command.Image == null)
            {
                return BadRequest();
            }

            try
            {
                string webRootPath = _env.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(command.Image.FileName);
                string filePath = Path.Combine(webRootPath, "Images", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await command.Image.CopyToAsync(fileStream);
                }

                return Ok(await _mediator.Send(new UpdateProductPhotoCommand(1, fileName, filePath)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{ProductId}")]
        public async Task<IActionResult> DeletePhoto(int ProductId)
        {
            try
            {
                return Ok(await _mediator.Send(new DeleteProductPhotoCommand(ProductId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<PhysicalFileResult> GetPhoto([FromRoute] int Id)
        {
            var res = await _mediator.Send(new GetProductPhotoQuery(Id));

            return PhysicalFile(res.Item1, res.Item2);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllPhotos()
        {
            return Ok(await _mediator.Send(new GetAllPhotoQuery()));
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
