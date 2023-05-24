using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicPlatform.Business.Dtos;
using MusicPlatform.Business.Services;

namespace MusicPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/artists")]
    public class ArtistController : ControllerBase
    {
        private readonly ArtistService artistService;

        public ArtistController(ArtistService artistService)
        {
            this.artistService = artistService ?? throw new ArgumentNullException(nameof(artistService));
        }

        [HttpGet("get-all")]
        public ActionResult<List<ArtistDto>> GetAll()
        {
            var artists = artistService.GetAll();
            return Ok(artists);
        }
    }
}
