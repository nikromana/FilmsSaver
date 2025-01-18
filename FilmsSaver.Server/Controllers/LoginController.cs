using Microsoft.AspNetCore.Mvc;

namespace FilmsSaver.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController(ILogger<WeatherForecastController> _logger) : ControllerBase
    {
        public async Task<IActionResult> Login ()
        {
            return Ok("Login was success.");
        }

        public async Task<IActionResult> Registration ()
        {
            return Ok("Registartion was success.");
        }
    }
}
