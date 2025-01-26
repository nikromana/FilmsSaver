using Microsoft.AspNetCore.Mvc;

namespace FilmsSaver.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController(ILogger<WeatherForecastController> _logger) : ControllerBase
    {
        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login([FromQuery] string qwe )
        {
            return Ok("Login was success.");
        }

        [HttpGet]
        [Route("registration")]
        public async Task<IActionResult> Registration ()
        {
            return Ok("Registartion was success.");
        }
    }
}
