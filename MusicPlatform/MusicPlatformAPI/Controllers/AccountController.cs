using Microsoft.AspNetCore.Mvc;
using MusicPlatform.Business.Dtos;
using MusicPlatform.Business.Services;

namespace MusicPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AuthenticationService authenticationService;

        public AccountController(AuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        [HttpPost("register/user")]
        public IActionResult RegisterUser([FromBody] UserDto request)
        {
            authenticationService.Register(request);
            return Ok();
        }

        [HttpPost("register/artist")]
        public IActionResult RegisterArtist([FromBody] ArtistDto request)
        {
            authenticationService.Register(request);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDto request)
        {
            var token = authenticationService.Validate(request);

            if (token != null)
            {
                return Ok(token);
            }

            return Unauthorized();
        }
    }
}
