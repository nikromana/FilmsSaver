using Application.Queries.Login;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace FilmsSaver.Server.Controllers
{
    [Route("[controller]")]
    public class FilmController(OmdbApiService _omdbApi) : ControllerBase
    {
        [HttpGet("search")]
        [EnableCors("MyPolicy")]
        public async Task<IActionResult> SearchFilms([FromQuery] string filmSearch, CancellationToken token)
        {
            var films = await _omdbApi.SearchFilms(filmSearch);

            return Ok(films);
        }
    }
}
