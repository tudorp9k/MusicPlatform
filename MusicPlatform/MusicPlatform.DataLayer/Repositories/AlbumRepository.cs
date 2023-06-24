using MusicPlatform.DataLayer.Models;

namespace MusicPlatform.DataLayer.Repositories
{
    public class AlbumRepository : RepositoryBase<Album>
    {
        public AlbumRepository(MusicDbContext dbContext) : base(dbContext)
        {
        }
    }
}
