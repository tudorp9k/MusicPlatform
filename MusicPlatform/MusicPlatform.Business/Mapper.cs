﻿using MusicPlatform.Business.Dtos;
using MusicPlatform.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlatform.Business
{
    public static class Mapper
    {
        public static ArtistDto MapToArtistDTO(Artist artist)
        {
            return new ArtistDto
            {
                Username = artist.Username,
                PasswordHash = artist.PasswordHash,
                Name = artist.Name,
                Description = artist.Description,
                Genre = artist.Genre.ToString()
            };
        }
    }
}
