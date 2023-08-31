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
        public static UserDto MapToUserDTO(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.PasswordHash,
                Role = user.Role,
            };
        }
        public static ArtistDto MapToArtistDTO(Artist artist)
        {
            return new ArtistDto
            {
                Id = artist.Id,
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
                Id = song.Id,
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
                Id = album.Id,
                Name = album.Name,
                ReleaseDate = album.ReleaseDate.ToString()
            };
        }

        public static FullAlbumDTO MapToFullAlbumDTO(Album album)
        {
            return new FullAlbumDTO
            {
                Id = album.Id,
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
                Id = single.Id,
                Name = single.Name,
                ReleaseDate = single.ReleaseDate.ToString()
            };
        }

        public static FullSingleDTO MapToFullSingleDTO(Single single)
        {
            return new FullSingleDTO
            {
                Id = single.Id,
                ArtistId = (int)single.ArtistId,
                Name = single.Name,
                ReleaseDate = single.ReleaseDate.ToString(),
                Song = MapToSongDTO(single.Song),
            };
        }

        public static DetailPlaylistDTO MapToDetailPlaylistDTO(Playlist playlist)
        {
            return new DetailPlaylistDTO
            {
                Id = playlist.Id,
                Name = playlist.Name,
                Description = playlist.Description,
            };
        }

        public static FullPlaylistDTO MapToFullPlaylistDTO(Playlist playlist)
        {
            return new FullPlaylistDTO
            {
                Id = playlist.Id,
                Name = playlist.Name,
                Description = playlist.Description,
                UserId = playlist.UserId,
                Songs = playlist.Songs.Select(s => MapToSongDTO(s)).ToList(),

            };
        }

        public static DetailEPDto MapToDetailEpDTO(EP ep)
        {
            return new DetailEPDto
            {
                Id = ep.Id,
                Name = ep.Name,
                ReleaseDate = ep.ReleaseDate.ToString(),
            };
        }

        public static FullEpDto MapToFullEpDTO(EP ep)
        {
            return new FullEpDto
            {
                Id = ep.Id,
                Name = ep.Name,
                ReleaseDate = ep.ReleaseDate.ToString(),
                ArtistId = ep.ArtistId,
                Songs = ep.Songs.Select(s => MapToSongDTO(s)).ToList(),
            };
        }
    }
}
