using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace MusicPlatform.DataLayer
{
    internal class MusicDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MusicPlatform"].ConnectionString);
        }
    }
}
