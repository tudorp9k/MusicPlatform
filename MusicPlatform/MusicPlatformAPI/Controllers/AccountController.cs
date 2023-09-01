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

        [HttpGet("all-users")]
        public ActionResult<List<UserDto>> Get()
        {
            var users = authenticationService.GetAllUsers();
            return Ok(users);
        }

        [HttpPost("register-listener")]
        public IActionResult RegisterUser([FromBody] AuthenticateUserDto request)
        {
            authenticationService.Register(request);
            return Ok();
        }

        [HttpPost("register-artist")]
        public IActionResult RegisterArtist([FromBody] RegisterArtistDto request)
        {
            authenticationService.Register(request);
            return Ok();
        }

        [HttpPost("register-admin")]
        public IActionResult RegisterAdmin([FromBody] AuthenticateUserDto request)
        {
            authenticationService.RegisterAdmin(request);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateUserDto request)
        {
            var token = authenticationService.Validate(request);

            if (token != null)
            {
                return Ok(token);
            }

            return Unauthorized();
        }

        [HttpDelete("delete/{userId}")]
        public IActionResult Delete(int userId)
        {
            authenticationService.DeleteUser(userId);
            return Ok();
        }
    }
}
