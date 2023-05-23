using MusicPlatform.DataLayer.Models;

namespace MusicPlatform.DataLayer.Repositories
{
    internal class SongRepository : RepositoryBase<Song>
    {
        public SongRepository(MusicDbContext dbContext) : base(dbContext)
        {
        }
    }
}
