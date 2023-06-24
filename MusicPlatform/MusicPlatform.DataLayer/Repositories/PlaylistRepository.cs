using MusicPlatform.DataLayer.Models;

namespace MusicPlatform.DataLayer.Repositories
{
    public class PlaylistRepository : RepositoryBase<Playlist>
    {
        public PlaylistRepository(MusicDbContext dbContext) : base(dbContext)
        {
        }
    }
}
