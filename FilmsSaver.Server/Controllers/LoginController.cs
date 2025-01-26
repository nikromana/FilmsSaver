using Application.Queries.Login;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FilmsSaver.Server.Controllers
{
    [Route("[controller]")]
    public class LoginController(ILogger<WeatherForecastController> _logger) : ControllerBase
    {
        [HttpGet("login")]
        [EnableCors("MyPolicy")]
        public async Task<IActionResult> Login([FromQuery] LoginQuery loginQuery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
