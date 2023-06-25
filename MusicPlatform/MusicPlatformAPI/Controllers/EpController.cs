using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicPlatform.Business.Dtos;
using MusicPlatform.Business.Services;
using MusicPlatform.DataLayer.Models;
using System.Data;

namespace MusicPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EpController : ControllerBase
    {
        private readonly EpService epService;

        public EpController(EpService epService)
        {
            this.epService = epService ?? throw new ArgumentNullException(nameof(epService));
        }

        [HttpGet("get-all")]
        [AllowAnonymous]
        public ActionResult<List<EpDto>> GetAll()
        {
            var eps = epService.GetAll();

            return Ok(eps);
        }

        [HttpGet("get/{epId}")]
        [AllowAnonymous]
        public ActionResult<EpDto> Get(int epId)
        {
            var ep = epService.GetById(epId);

            return Ok(ep);
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin,Artist")]
        public IActionResult Add(EpDto ep, int artistId)
        {
            var result = epService.AddEP(ep, artistId);

            if (result == null)
            {
                return BadRequest("EP could not be added");
            }

            return Ok(result);
        }

        [HttpPost("add-song")]
        [Authorize(Roles = "Admin,Artist")]
        public IActionResult AddSong(int songId, int epId)
        {
            var userId = User.FindFirst("userId")?.Value;

            var ep = epService.GetById(epId);

            if (ep.ArtistId.ToString() != userId)
            {
                return Forbid();
            }

            var result = epService.AddSongToEP(songId, epId);

            if (!result)
            {
                return BadRequest("Song could not be added to EP");
            }

            return Ok();
        }

        [HttpPatch("edit")]
        [Authorize(Roles = "Admin,Artist")]
        public IActionResult Edit(UpdateEpDto epUpdate)
        {
            var userId = User.FindFirst("userId")?.Value;

            if (epUpdate.ArtistId.ToString() != userId)
            {
                return Forbid();
            }

            var result = epService.UpdateEP(epUpdate);

            if (!result)
            {
                return BadRequest("EP could not be updated");
            }

            return Ok();
        }

        [HttpDelete("delete/{epId}")]
        [Authorize(Roles = "Admin,Artist")]
        public IActionResult Delete(int epId)
        {
            var userId = User.FindFirst("userId")?.Value;

            var ep = epService.GetById(epId);

            if (ep.ArtistId.ToString() != userId)
            {
                return Forbid();
            }

            var result = epService.DeleteEP(epId);

            if (!result)
            {
                return BadRequest("EP could not be deleted");
            }

            return Ok();
        }
    }
}
