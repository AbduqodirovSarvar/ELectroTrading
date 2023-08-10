using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectroTrading.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TgBotController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TgBotController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_configuration.GetSection("TelegramBot:UserIds").Value?.Split(',').Select(long.Parse).ToList());
        }
    }
}
