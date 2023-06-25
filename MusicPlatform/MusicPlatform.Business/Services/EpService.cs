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
    public class EpService
    {
        private readonly UnitOfWork unitOfWork;

        public EpService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public List<DetailEPDto> GetAll()
        {
            var eps = unitOfWork.EPs.GetAll();

            if (eps == null)
            {
                throw new EpNotFoundException();
            }

            return eps.Select(e => Mapper.MapToDetailEpDTO(e)).ToList();
        }

        public FullEpDto GetById(int epId)
        {
            var ep = unitOfWork.EPs.GetByIdWithArtistAndSongs(epId);

            if (ep == null)
            {
                throw new EpNotFoundException();
            }

            return Mapper.MapToFullEpDTO(ep);
        }

        public DetailEPDto AddEP(DetailEPDto payload, int artistId)
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

            var ep = new EP
            {
                Name = payload.Name,
                ReleaseDate = DateTime.Parse(payload.ReleaseDate),
                ArtistId = artistId,
                Artist = artist,
            };

            unitOfWork.EPs.Insert(ep);
            unitOfWork.SaveChanges();

            return Mapper.MapToDetailEpDTO(ep);
        }

        public bool AddSongToEP(int songId, int epId)
        {
            var song = unitOfWork.Songs.GetById(songId);
            var ep = unitOfWork.EPs.GetById(epId);

            if (song == null)
            {
                throw new SongNotFoundException();
            }

            if (ep == null)
            {
                throw new EpNotFoundException();
            }

            song.EPId = epId;
            song.EP = ep;

            unitOfWork.Songs.Update(song);
            unitOfWork.SaveChanges();

            return true;
        }

        public bool UpdateEP(UpdateEpDto payload)
        {
            if (payload == null)
            {
                return false;
            }

            var ep = unitOfWork.EPs.GetById(payload.Id);

            if (ep == null)
            {
                throw new EpNotFoundException();
            }

            ep.Name = payload.Name;
            ep.ReleaseDate = DateTime.Parse(payload.ReleaseDate);

            unitOfWork.EPs.Update(ep);
            unitOfWork.SaveChanges();

            return true;
        }

        public bool DeleteEP(int epId)
        {
            var ep = unitOfWork.EPs.GetById(epId);

            if (ep == null)
            {
                throw new EpNotFoundException();
            }

            unitOfWork.EPs.Remove(ep);
            unitOfWork.SaveChanges();

            return true;
        }
    }

}
