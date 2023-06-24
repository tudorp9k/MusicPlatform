using Microsoft.EntityFrameworkCore;
using MusicPlatform.DataLayer.Models;

namespace MusicPlatform.DataLayer.Repositories
{
    public class AlbumRepository : RepositoryBase<Album>
    {
        private readonly MusicDbContext dbContext;

        public AlbumRepository(MusicDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Album GetByIdWithArtistAndSongs(int albumId)
        {
            var result = dbContext.Albums
                .Where(x => x.Id == albumId)
                .Include(x => x.Artist)
                .Include(x => x.Songs)
                .FirstOrDefault();

            return result;
        }
    }
}
