using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicPlatform.Business.Dtos;
using MusicPlatform.Business.Services;
using MusicPlatform.DataLayer.Enums;
using MusicPlatform.DataLayer.Models;

namespace MusicPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly AlbumService albumService;

        public AlbumController(AlbumService albumService)
        {
            this.albumService = albumService ?? throw new ArgumentNullException(nameof(albumService));
        }

        [HttpGet("get-all")]
        [AllowAnonymous]
        public ActionResult<List<DetailAlbumDTO>> GetAll()
        {
            var albums = albumService.GetAll();

            return Ok(albums);
        }

        [HttpGet("get/{albumId}")]
        [AllowAnonymous]
        public ActionResult<FullAlbumDTO> Get(int albumId)
        {
            var album = albumService.GetById(albumId);

            return Ok(album);
        }

        [HttpPost("add/{artistId}")]
        [Authorize(Roles = "Admin,Artist")]
        public IActionResult Add(AddAlbumDto album, int artistId)
        {
            var userId = User.FindFirst("userId")?.Value;

            if (!User.IsInRole("Admin"))
            {
                if (artistId.ToString() != userId)
                {
                    return Forbid();
                }
            }

            var result = albumService.AddAlbum(album, artistId);

            if (result == null)
            {
                return BadRequest("Album could not be added");
            }

            return Ok(result);
        }

        [HttpPost("add-song/{songId}/{albumId}")]
        [Authorize(Roles = "Admin,Artist")]
        public IActionResult AddSong(int songId, int albumId)
        {
            var userId = User.FindFirst("userId")?.Value;

            var album = albumService.GetById(albumId);

            if (!User.IsInRole("Admin"))
            {
                if (album.ArtistId.ToString() != userId)
                {
                    return Forbid();
                }
            }

            var result = albumService.AddSongToAlbum(songId, albumId);

            if (!result)
            {
                return BadRequest("Song could not be added to album");
            }

            return Ok();
        }

        [HttpPut("edit")]
        [Authorize(Roles = "Admin,Artist")]
        public IActionResult Edit(UpdateAlbumDTO albumUpdate)
        {
            var userId = User.FindFirst("userId")?.Value;

            if (!User.IsInRole("Admin"))
            {
                if (albumUpdate.Id.ToString() != userId)
                {
                    return Forbid();
                }
            }

            var result = albumService.UpdateAlbum(albumUpdate);

            if (!result)
            {
                return BadRequest("Album could not be updated");
            }

            return Ok();
        }

        [HttpDelete("delete/{albumId}")]
        [Authorize(Roles = "Admin,Artist")]
        public IActionResult Delete(int albumId)
        {
            var userId = User.FindFirst("userId")?.Value;

            var album = albumService.GetById(albumId);

            if (!User.IsInRole("Admin"))
            {
                if (album.ArtistId.ToString() != userId)
                {
                    return Forbid();
                }
            }

            var result = albumService.DeleteAlbum(albumId);

            if (!result)
            {
                return BadRequest("Album could not be deleted");
            }

            return Ok();
        }
    }
}
