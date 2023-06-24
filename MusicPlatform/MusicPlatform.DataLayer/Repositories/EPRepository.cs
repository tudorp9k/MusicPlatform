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
        public EPRepository(MusicDbContext dbContext) : base(dbContext)
        {
        }
    }
}
