using MusicPlatform.Business.Dtos;
using MusicPlatform.Business.Exceptions;
using MusicPlatform.DataLayer;
using MusicPlatform.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlatform.Business.Services
{
    public class AlbumService
    {
        private readonly UnitOfWork unitOfWork;

        public AlbumService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public List<DetailAlbumDTO> GetAll()
        {
            var albums = unitOfWork.Albums.GetAll();

            if (albums == null)
            {
                throw new AlbumNotFoundException();
            }

            return albums.Select(a => Mapper.MapToDetailAlbumDTO(a)).ToList();
        }

        public FullAlbumDTO GetById(int albumId)
        {
            var album = unitOfWork.Albums.GetByIdWithArtistAndSongs(albumId);

            if (album == null)
            {
                throw new AlbumNotFoundException();
            }

            return Mapper.MapToFullAlbumDTO(album);
        }

        public DetailAlbumDTO AddAlbum(DetailAlbumDTO payload, int artistId)
        {
            if (payload == null)
            {
                return null;
            }

            var artist = unitOfWork.Artists.GetById(artistId);

            if (artist == null)
            {
                throw new ArtistNotFoundException();
            }

            var album = new Album
            {
                Name = payload.Name,
                ReleaseDate = DateTime.Parse(payload.ReleaseDate),
                ArtistId = artistId,
                Artist = artist,
            };

            unitOfWork.Albums.Insert(album);
            unitOfWork.SaveChanges();

            return Mapper.MapToDetailAlbumDTO(album);
        }

        public bool AddSongToAlbum(int songId, int albumId)
        {
            var song = unitOfWork.Songs.GetById(songId);
            var album = unitOfWork.Albums.GetById(albumId);

            if (song == null)
            {
                throw new SongNotFoundException();
            }

            if (album == null)
            {
                throw new AlbumNotFoundException();
            }

            song.AlbumId = albumId;
            song.Album = album;

            unitOfWork.Songs.Update(song);
            unitOfWork.SaveChanges();

            return true;
        }

        public bool UpdateAlbum(UpdateAlbumDTO payload)
        {
            if (payload == null)
            {
                return false;
            }

            var result = unitOfWork.Albums.GetById(payload.Id);

            if (result == null)
            {
                throw new AlbumNotFoundException();
            }

            result.Name = payload.Name;
            result.ReleaseDate = DateTime.Parse(payload.ReleaseDate);

            unitOfWork.Albums.Update(result);
            unitOfWork.SaveChanges();

            return true;
        }

        public bool DeleteAlbum(int albumId)
        {
            var result = unitOfWork.Albums.GetById(albumId);

            if (result == null)
            {
                throw new AlbumNotFoundException();
            }

            unitOfWork.Albums.Remove(result);
            unitOfWork.SaveChanges();

            return true;
        }
    }
}
