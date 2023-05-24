using MusicPlatform.DataLayer.Models;

namespace MusicPlatform.DataLayer.Repositories
{
    public class ArtistRepository : RepositoryBase<Artist>
    {
        public ArtistRepository(MusicDbContext dbContext) : base(dbContext)
        {
        }

        public Artist GetByUsername(string username)
        {
            return GetRecords().FirstOrDefault(x => x.Username == username);
        }
    }
}
