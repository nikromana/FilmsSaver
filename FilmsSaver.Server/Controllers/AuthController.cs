using Application.Commands.Registration;
using Application.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Model;
using Services;
using System.Text.Json;

namespace FilmsSaver.Server.Controllers
{
    [Route("[controller]")]
    public class AuthController(ILogger<AuthController> _logger, 
        IMediator _mediatr, JwtTockenService _jwtTokenService) : ControllerBase

    {
        [HttpGet("login")]
        [EnableCors("MyPolicy")]
        public async Task<IActionResult> Login([FromQuery] LoginQuery loginQuery , CancellationToken token)
        {
            var responce = await _mediatr.Send(loginQuery, token);

            if (!ModelState.IsValid || responce == null)
            {
                return BadRequest(new { Errors = "Error login" });
            }

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
                WriteIndented = true  
            };

            string jsonString = JsonSerializer.Serialize(new { Token = _jwtTokenService.GenerateJwtToken(responce.UserName, responce.Id), Films = responce.SavedFilms }, options);

            return Ok(jsonString);
        }
        [HttpGet]
        [Route("registration")]
        public async Task<IActionResult> Registration([FromQuery] RegistrationCommand registrationCommand, CancellationToken token)
        {
            var result = await _mediatr.Send(registrationCommand, token);

            if(!string.IsNullOrWhiteSpace(result.Error))
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Error);
        }
    }
}
