using Application.Commands.Registration;
using Application.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FilmsSaver.Server.Controllers
{
    [Route("[controller]")]
    public class AuthController(ILogger<AuthController> _logger, IMediator _mediatr) : ControllerBase
    {
        [HttpGet("login")]
        [EnableCors("MyPolicy")]
        public async Task<IActionResult> Login([FromQuery] LoginQuery loginQuery , CancellationToken token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = "Error login"});
            }
            return Ok(new {Responce = "Login was success." });
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
