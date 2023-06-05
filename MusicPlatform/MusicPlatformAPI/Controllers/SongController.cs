using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicPlatform.Business.Dtos;
using MusicPlatform.Business.Services;
using MusicPlatformAPI.Filters;

namespace MusicPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongController : ControllerBase
    {
        private readonly SongService songService;

        public SongController(SongService songService)
        {
            this.songService = songService ?? throw new ArgumentNullException(nameof(songService));
        }

        [HttpGet("/song-get-all")]
        public ActionResult<List<SongDto>> GetAll()
        {
            var songs = songService.GetAll();

            return Ok(songs);
        }

        [HttpGet("/get/{songId}")]
        public ActionResult<SongDto> Get(int songId)
        {
            var song = songService.GetById(songId);

            return Ok(song);
        }

        [HttpPatch("edit")]
        [Authorize(Roles = "Admin,Artist")]
        public IActionResult Edit(SongUpdateDto songUpdate)
        {
            var result = songService.UpdateSong(songUpdate);

            if (!result)
            {
                return BadRequest("Song could not be updated");
            }

            return Ok();
        }

        [HttpDelete("delete")]
        [Authorize(Roles = "Admin,Artist")]
        public IActionResult Delete(int songId)
        {
            var result = songService.DeleteSong(songId);

            if (!result)
            {
                return BadRequest("Song could not be deleted");
            }

            return Ok();
        }

    }
}
