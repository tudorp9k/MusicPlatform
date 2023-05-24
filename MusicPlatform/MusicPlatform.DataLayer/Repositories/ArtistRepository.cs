using MusicPlatform.DataLayer.Models;

namespace MusicPlatform.DataLayer.Repositories
{
    public class ArtistRepository : RepositoryBase<Artist>
    {
        public ArtistRepository(MusicDbContext dbContext) : base(dbContext)
        {
        }
    }
}
