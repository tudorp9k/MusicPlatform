using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlatform.DataLayer.Models;

namespace MusicPlatform.DataLayer.Repositories
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(MusicDbContext dbContext) : base(dbContext)
        {
        }

        public User GetByUsername(string username)
        {
            return GetRecords().FirstOrDefault(u => u.Username == username);
        }
    }
}
