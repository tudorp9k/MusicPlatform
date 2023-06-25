using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlatform.Business.Exceptions;
using MusicPlatform.DataLayer.Models;
using MusicPlatform.DataLayer;
using MusicPlatform.Business.Dtos;

namespace MusicPlatform.Business.Services
{
    public class PlaylistService
    {
        private readonly UnitOfWork unitOfWork;

        public PlaylistService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public List<DetailPlaylistDTO> GetAll()
        {
            var playlists = unitOfWork.Playlists.GetAll();

            if (playlists == null)
            {
                throw new PlaylistNotFoundException();
            }

            return playlists.Select(p => Mapper.MapToDetailPlaylistDTO(p)).ToList();
        }

        public FullPlaylistDTO GetById(int playlistId)
        {
            var playlist = unitOfWork.Playlists.GetByIdWithArtistAndSongs(playlistId);

            if (playlist == null)
            {
                throw new PlaylistNotFoundException();
            }

            return Mapper.MapToFullPlaylistDTO(playlist);
        }

        public DetailPlaylistDTO AddPlaylist(DetailPlaylistDTO payload, int userId)
        {
            if (payload == null)
            {
                return null;
            }

            var user = unitOfWork.Users.GetById(userId);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            var playlist = new Playlist
            {
                Name = payload.Name,
                Description = payload.Description,
                UserId = userId,
                User = user,
            };

            unitOfWork.Playlists.Insert(playlist);
            unitOfWork.SaveChanges();

            return Mapper.MapToDetailPlaylistDTO(playlist);
        }

        public bool AddSongToPlaylist(int songId, int playlistId)
        {
            var song = unitOfWork.Songs.GetById(songId);
            var playlist = unitOfWork.Playlists.GetById(playlistId);

            if (song == null)
            {
                throw new SongNotFoundException();
            }

            if (playlist == null)
            {
                throw new PlaylistNotFoundException();
            }

            song.Playlist = playlist;
            song.PlaylistId = playlistId;

            unitOfWork.Playlists.Update(playlist);
            unitOfWork.SaveChanges();

            return true;
        }

        public bool UpdatePlaylist(UpdatePlaylistDTO payload)
        {
            if (payload == null)
            {
                return false;
            }

            var playlist = unitOfWork.Playlists.GetById(payload.Id);

            if (playlist == null)
            {
                throw new PlaylistNotFoundException();
            }

            playlist.Name = payload.Name;
            playlist.Description = payload.Description;

            unitOfWork.Playlists.Update(playlist);
            unitOfWork.SaveChanges();

            return true;
        }

        public bool DeletePlaylist(int playlistId)
        {
            var playlist = unitOfWork.Playlists.GetById(playlistId);

            if (playlist == null)
            {
                throw new PlaylistNotFoundException();
            }

            unitOfWork.Playlists.Remove(playlist);
            unitOfWork.SaveChanges();

            return true;
        }
    }

}
