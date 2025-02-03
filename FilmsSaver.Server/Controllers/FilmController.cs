using Application.Queries.Login;
using Application.Queries.SaveFilm;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace FilmsSaver.Server.Controllers
{
    [Route("[controller]")]
    public class FilmController(OmdbApiService _omdbApi, 
        IMediator _mediatr) : ControllerBase
    {
        [HttpGet("search")]
        [EnableCors("MyPolicy")]
        public async Task<IActionResult> SearchFilms([FromQuery] string filmSearch, CancellationToken token)
        {
            var films = await _omdbApi.SearchFilms(filmSearch);

            return Ok(films);
        }

        [HttpPost("save")]
        [EnableCors("MyPolicy")]
        public async Task<IActionResult> SaveFilm([FromBody] SaveFilmQuery filmName, CancellationToken token)
        {
            var result = await _mediatr.Send(filmName, token);

            return Ok(result);
        }
    }
}
