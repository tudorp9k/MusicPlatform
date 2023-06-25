using System.Data;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicPlatform.Business.Dtos;
using MusicPlatform.Business.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MusicPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistController : ControllerBase
    {
        private readonly PlaylistService playlistService;

        public PlaylistController(PlaylistService playlistService)
        {
            this.playlistService = playlistService ?? throw new ArgumentNullException(nameof(playlistService));
        }

        [HttpGet("get-all")]
        [AllowAnonymous]
        public ActionResult<List<DetailPlaylistDTO>> GetAll()
        {
            var playlists = playlistService.GetAll();

            return Ok(playlists);
        }

        [HttpGet("get/{playlistId}")]
        [AllowAnonymous]
        public ActionResult<FullPlaylistDTO> Get(int playlistId)
        {
            var playlist = playlistService.GetById(playlistId);

            return Ok(playlist);
        }

        [HttpPost("add")]
        [Authorize(Roles = "Listener,Admin,Artist")]
        public IActionResult Add(DetailPlaylistDTO playlist, int userId)
        {
            var result = playlistService.AddPlaylist(playlist, userId);

            if (result == null)
            {
                return BadRequest("Playlist could not be added");
            }

            return Ok(result);
        }

        [HttpPost("add-song")]
        [Authorize(Roles = "Listener,Admin,Artist")]
        public IActionResult AddSong(int songId, int playlistId)
        {
            var userId = User.FindFirst("userId")?.Value;

            var playlist = playlistService.GetById(playlistId);

            if (!User.IsInRole("Admin"))
            {
                if (playlist.UserId.ToString() != userId)
                {
                    return Forbid();
                }
            }

            var result = playlistService.AddSongToPlaylist(songId, playlistId);

            if (!result)
            {
                return BadRequest("Song could not be added to playlist");
            }

            return Ok();
        }

        [HttpPatch("edit")]
        [Authorize(Roles = "Listener,Admin,Artist")]
        public IActionResult Edit(UpdatePlaylistDTO playlistUpdate)
        {
            var userId = User.FindFirst("userId")?.Value;

            if (!User.IsInRole("Admin"))
            {
                if (playlistUpdate.UserId.ToString() != userId)
                {
                    return Forbid();
                }
            }

            var result = playlistService.UpdatePlaylist(playlistUpdate);

            if (!result)
            {
                return BadRequest("Playlist could not be updated");
            }

            return Ok();
        }

        [HttpDelete("delete/{playlistId}")]
        [Authorize(Roles = "Listener,Admin,Artist")]
        public IActionResult Delete(int playlistId)
        {
            var userId = User.FindFirst("userId")?.Value;

            var playlist = playlistService.GetById(playlistId);

            if (!User.IsInRole("Admin"))
            {
                if (playlist.UserId.ToString() != userId)
                {
                    return Forbid();
                }
            }

            var result = playlistService.DeletePlaylist(playlistId);

            if (!result)
            {
                return BadRequest("Playlist could not be deleted");
            }

            return Ok();
        }
    }
}

