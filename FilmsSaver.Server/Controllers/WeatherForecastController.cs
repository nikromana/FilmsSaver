using Microsoft.AspNetCore.Mvc;

namespace FilmsSaver.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
    {
        [HttpGet(Name = "GetFilm")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
