using MusicPlatform.DataLayer.Models;

namespace MusicPlatform.DataLayer.Repositories
{
    public class SongRepository : RepositoryBase<Song>
    {
        public SongRepository(MusicDbContext dbContext) : base(dbContext)
        {
        }
    }
}
