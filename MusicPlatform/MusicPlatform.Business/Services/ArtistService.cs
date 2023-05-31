using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlatform.Business.Dtos;
using MusicPlatform.Business.Exceptions;
using MusicPlatform.DataLayer;
using MusicPlatform.DataLayer.Enums;
using MusicPlatform.DataLayer.Models;

namespace MusicPlatform.Business.Services
{
    public class ArtistService
    {
        private readonly UnitOfWork unitOfWork;

        private readonly AuthorizationService authService;

        public ArtistService(UnitOfWork unitOfWork, AuthorizationService authService)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        public List<ArtistDto> GetAll()
        {
            var artists = unitOfWork.Artists.GetAll();

            if (artists == null)
            {
                throw new ArtistNotFoundException();
            }

            return artists.Select(a => Mapper.MapToArtistDTO(a)).ToList();
        }

        public ArtistDto GetById(int artistId)
        {
            var artist = unitOfWork.Artists.GetById(artistId);

            if (artist == null)
            {
                throw new ArtistNotFoundException();
            }

            return Mapper.MapToArtistDTO(artist);
        }

        public bool UpdateArtist(ArtistUpdateDto payload)
        {
            if (payload == null)
            {
                return false;
            }

            var result = unitOfWork.Artists.GetById(payload.Id);

            result.Name = payload.Name;
            result.Description = payload.Description;
            result.Genre = (Genre)Enum.Parse(typeof(Genre), payload.Genre);

            unitOfWork.Artists.Update(result);
            unitOfWork.SaveChanges();

            return true;
        }

        public bool DeleteArtist(int artistId)
        {
            var artist = unitOfWork.Artists.GetById(artistId);

            unitOfWork.Artists.Remove(artist);
            unitOfWork.SaveChanges();

            return true;
        }
    }
}
