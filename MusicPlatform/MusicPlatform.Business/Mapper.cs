using MusicPlatform.Business.Dtos;
using MusicPlatform.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Single = MusicPlatform.DataLayer.Models.Single;

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

        public static SongDto MapToSongDTO(Song song)
        {
            return new SongDto
            {
                Name = song.Name,
                Genre = song.Genre.ToString(),
                Likes = song.Likes,
                Streams = song.Streams,
                ArtistId = song.ArtistId
            };
        }

        public static DetailAlbumDTO MapToDetailAlbumDTO(Album album)
        {
            return new DetailAlbumDTO
            {
                Name = album.Name,
                ReleaseDate = album.ReleaseDate.ToString()
            };
        }

        public static FullAlbumDTO MapToFullAlbumDTO(Album album)
        {
            return new FullAlbumDTO
            {
                Name = album.Name,
                ReleaseDate = album.ReleaseDate.ToString(),
                ArtistName = album.Artist.Name,
                Songs = album.Songs.Select(s => MapToSongDTO(s)).ToList(),
                ArtistId = album.ArtistId
            };
        }

        public static DetailSingleDTO MapToDetailSingleDTO(Single single)
        {
            return new DetailSingleDTO
            {
                Name = single.Name,
                ReleaseDate = single.ReleaseDate.ToString()
            };
        }

        public static FullSingleDTO MapToFullSingleDTO(Single single)
        {
            return new FullSingleDTO
            {
                ArtistId = (int)single.ArtistId,
                Name = single.Name,
                ReleaseDate = single.ReleaseDate.ToString(),
                Song = MapToSongDTO(single.Song),
            };
        }
    }
}
