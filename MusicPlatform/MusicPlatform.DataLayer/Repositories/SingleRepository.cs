using Single = MusicPlatform.DataLayer.Models.Single;

namespace MusicPlatform.DataLayer.Repositories
{
    public class SingleRepository : RepositoryBase<Single>
    {
        public SingleRepository(MusicDbContext dbContext) : base(dbContext)
        {
        }
    }
}
