using MusicPlatform.DataLayer.Models;

namespace MusicPlatform.DataLayer.Repositories
{
    internal class ArtistRepository : RepositoryBase<Artist>
    {
        public ArtistRepository(MusicDbContext dbContext) : base(dbContext)
        {
        }
    }
}
