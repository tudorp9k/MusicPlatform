using Microsoft.EntityFrameworkCore;
using MusicPlatform.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlatform.DataLayer.Repositories
{
    public class EPRepository : RepositoryBase<EP>
    {
        private readonly MusicDbContext dbContext;

        public EPRepository(MusicDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public EP GetByIdWithArtistAndSongs(int albumId)
        {
            var result = dbContext.EPs
                .Where(x => x.Id == albumId)
                .Include(x => x.Artist)
                .Include(x => x.Songs)
                .FirstOrDefault();

            return result;
        }
    }
}
