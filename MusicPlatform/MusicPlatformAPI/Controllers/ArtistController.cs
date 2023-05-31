using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicPlatform.Business.Dtos;
using MusicPlatform.Business.Services;

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
        [AllowAnonymous]
        public ActionResult<List<ArtistDto>> GetAll()
        {
            var artists = artistService.GetAll();

            if (artists == null)
            {
                return BadRequest("No artists found");
            }

            return Ok(artists);
        }

        [HttpGet("/get/{artistId}")]
        [AllowAnonymous]
        public ActionResult<ArtistDto> Get(int artistId)
        {
            var artist = artistService.GetById(artistId);

            if (artist == null)
            {
                return BadRequest("Artist not found");
            }

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
