using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlatform.Business.Dtos;
using MusicPlatform.Business.Exceptions;
using MusicPlatform.DataLayer.Enums;
using MusicPlatform.DataLayer;

namespace MusicPlatform.Business.Services
{
    public class SongService
    {
        private readonly UnitOfWork unitOfWork;

        private readonly AuthorizationService authService;

        public SongService(UnitOfWork unitOfWork, AuthorizationService authService)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        public List<SongDto> GetAll()
        {
            var songs = unitOfWork.Songs.GetAll();

            if (songs == null)
            {
                throw new SongNotFoundException();
            }

            return songs.Select(a => Mapper.MapToSongDTO(a)).ToList();
        }

        public SongDto GetById(int songId)
        {
            var song = unitOfWork.Songs.GetById(songId);

            if (song == null)
            {
                throw new ArtistNotFoundException();
            }

            return Mapper.MapToSongDTO(song);
        }

        public bool UpdateSong(SongUpdateDto payload)
        {
            if (payload == null)
            {
                return false;
            }

            var result = unitOfWork.Songs.GetById(payload.Id);

            if (result == null)
            {
                throw new SongNotFoundException();
            }

            result.Name = payload.Name;
            result.ArtistId = payload.ArtistId;
            result.Genre = (Genre)Enum.Parse(typeof(Genre), payload.Genre);

            unitOfWork.Songs.Update(result);
            unitOfWork.SaveChanges();

            return true;
        }

        public bool DeleteSong(int songId)
        {
            var song = unitOfWork.Songs.GetById(songId);

            if (song == null)
            {
                throw new SongNotFoundException();
            }

            unitOfWork.Songs.Remove(song);
            unitOfWork.SaveChanges();

            return true;
        }
    }
}
