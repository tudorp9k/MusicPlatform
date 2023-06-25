using Microsoft.EntityFrameworkCore;
using MusicPlatform.DataLayer.Models;

namespace MusicPlatform.DataLayer.Repositories
{
    public class PlaylistRepository : RepositoryBase<Playlist>
    {
        private readonly MusicDbContext dbContext;

        public PlaylistRepository(MusicDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public Playlist GetByIdWithArtistAndSongs(int albumId)
        {
            var result = dbContext.Playlists
                .Where(x => x.Id == albumId)
                .Include(x => x.User)
                .Include(x => x.Songs)
                .FirstOrDefault();

            return result;
        }
    }
}
