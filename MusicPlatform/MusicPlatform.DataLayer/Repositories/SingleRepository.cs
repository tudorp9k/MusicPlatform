using Microsoft.EntityFrameworkCore;
using Single = MusicPlatform.DataLayer.Models.Single;

namespace MusicPlatform.DataLayer.Repositories
{
    public class SingleRepository : RepositoryBase<Single>
    {
        private readonly MusicDbContext dbContext;

        public SingleRepository(MusicDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public Single GetByIdWithSong(int singleId)
        {
            var result = dbContext.Singles
                .Where(s => s.Id == singleId)
                .Include(s => s.Song)
                .FirstOrDefault();

            return result;
        }
    }
}
