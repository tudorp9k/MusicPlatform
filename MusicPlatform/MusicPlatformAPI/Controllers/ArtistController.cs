using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicPlatform.Business.Dtos;
using MusicPlatform.Business.Services;
using MusicPlatformAPI.Filters;

namespace MusicPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly ArtistService artistService;

        public ArtistController(ArtistService artistService)
        {
            this.artistService = artistService ?? throw new ArgumentNullException(nameof(artistService));
        }

        [HttpGet("/get-all")]
        public ActionResult<List<ArtistDto>> GetAll()
        {
            var artists = artistService.GetAll();

            return Ok(artists);
        }

        [HttpGet("/get/{artistId}")]
        public ActionResult<ArtistDto> Get(int artistId)
        {
            var artist = artistService.GetById(artistId);

            return Ok(artist);
        }

        [HttpPatch("edit")]
        [Authorize(Roles = "Admin,Artist")]
        public IActionResult Edit(ArtistUpdateDto artistUpdate)
        {
            var result = artistService.UpdateArtist(artistUpdate);

            if (!result)
            {
                return BadRequest("Artist could not be updated");
            }

            return Ok();
        }

        [HttpDelete("delete")]
        [Authorize(Roles = "Admin,Artist")]
        public IActionResult Delete(int artistId)
        {
            var result = artistService.DeleteArtist(artistId);

            if (!result)
            {
                return BadRequest("Artist could not be deleted");
            }

            return Ok();
        }

    }
}
