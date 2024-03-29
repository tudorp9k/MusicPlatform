﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicPlatform.Business.Dtos;
using MusicPlatform.Business.Services;

namespace MusicPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SingleController : ControllerBase
    {
        private readonly SingleService singleService;

        public SingleController(SingleService singleService)
        {
            this.singleService = singleService ?? throw new ArgumentNullException(nameof(singleService));
        }

        [HttpGet("get-all")]
        [AllowAnonymous]
        public ActionResult<List<DetailSingleDTO>> GetAll()
        {
            var singles = singleService.GetAll();

            return Ok(singles);
        }

        [HttpGet("get/{singleId}")]
        [AllowAnonymous]
        public ActionResult<DetailSingleDTO> Get(int singleId)
        {
            var single = singleService.GetById(singleId);

            return Ok(single);
        }

        [HttpPost("add/{artistId}")]
        [Authorize(Roles = "Admin,Artist")]
        public IActionResult Add(AddSingleDto single, int artistId)
        {
            var userId = User.FindFirst("userId")?.Value;

            if (artistId.ToString() != userId)
            {
                return Forbid();
            }

            var result = singleService.AddSingle(single, artistId);

            if (result == null)
            {
                return BadRequest("Single could not be added");
            }

            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(UpdateSingleDTO single)
        {
            var userId = User.FindFirst("userId")?.Value;

            if (!User.IsInRole("Admin"))
            {
                if (single.ArtistId.ToString() != userId)
                {
                    return Forbid();
                }
            }

            var result = singleService.UpdateSingle(single);

            if (!result)
            {
                return BadRequest("Single could not be updated");
            }

            return Ok();
        }

        [HttpPost("add-song/{songId}/{singleId}")]
        [Authorize(Roles = "Admin,Artist")]
        public IActionResult AddSongToSingle(int songId, int singleId)
        {
            var userId = User.FindFirst("userId")?.Value;

            var single = singleService.GetById(singleId);

            if (!User.IsInRole("Admin"))
            {
                if (single.ArtistId.ToString() != userId)
                {
                    return Forbid();
                }
            }

            var result = singleService.AddSongToSingle(songId, singleId);

            if (!result)
            {
                return BadRequest("Song could not be added to playlist");
            }

            return Ok();
        }

        [HttpDelete("delete/{singleId}")]
        public IActionResult Delete(int singleId)
        {
            var userId = User.FindFirst("userId")?.Value;

            var single = singleService.GetById(singleId);

            if (!User.IsInRole("Admin"))
            {
                if (single.ArtistId.ToString() != userId)
                {
                    return Forbid();
                }
            }

            var result = singleService.DeleteSingle(singleId);

            if (!result)
            {
                return BadRequest("Single could not be deleted");
            }

            return Ok();
        }
    }
}
