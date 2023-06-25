using MusicPlatform.Business.Dtos;
using MusicPlatform.Business.Exceptions;
using MusicPlatform.DataLayer;
using Single = MusicPlatform.DataLayer.Models.Single;

namespace MusicPlatform.Business.Services
{
    public class SingleService
    {
        private readonly UnitOfWork unitOfWork;

        public SingleService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public List<DetailSingleDTO> GetAll()
        {
            var singles = unitOfWork.Singles.GetAll();

            if (singles == null)
            {
                throw new SingleNotFoundException();
            }

            return singles.Select(s => Mapper.MapToDetailSingleDTO(s)).ToList();
        }

        public FullSingleDTO GetById(int singleId)
        {
            var single = unitOfWork.Singles.GetByIdWithSong(singleId);

            if (single == null)
            {
                throw new SingleNotFoundException();
            }

            return Mapper.MapToFullSingleDTO(single);
        }

        public DetailSingleDTO AddSingle(DetailSingleDTO payload, int artistId)
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

            var single = new Single
            {
                Name = payload.Name,
                ReleaseDate = DateTime.Parse(payload.ReleaseDate),
                ArtistId = artistId,
                Artist = artist
            };

            unitOfWork.Singles.Insert(single);
            unitOfWork.SaveChanges();

            return Mapper.MapToDetailSingleDTO(single);
        }

        public bool AddSongToSingle(int songId, int singleId)
        {
            var single = unitOfWork.Singles.GetById(singleId);

            if (single == null)
            {
                throw new SingleNotFoundException();
            }

            var song = unitOfWork.Songs.GetById(songId);

            if (song == null)
            {
                throw new SongNotFoundException();
            }

            song.SingleId = singleId;
            song.Single = single;

            unitOfWork.Singles.Update(single);
            unitOfWork.SaveChanges();

            return true;
        }

        public bool UpdateSingle(UpdateSingleDTO payload)
        {
            if (payload == null)
            {
                return false;
            }

            var result = unitOfWork.Singles.GetById(payload.Id);

            if (result == null)
            {
                throw new SingleNotFoundException();
            }

            result.Name = payload.Name;
            result.ReleaseDate = DateTime.Parse(payload.ReleaseDate);

            unitOfWork.Singles.Update(result);
            unitOfWork.SaveChanges();

            return true;
        }

        public bool DeleteSingle(int singleId)
        {
            var single = unitOfWork.Singles.GetById(singleId);

            if (single == null)
            {
                throw new SingleNotFoundException();
            }

            unitOfWork.Singles.Remove(single);
            unitOfWork.SaveChanges();

            return true;
        }
    }
}
