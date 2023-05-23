using Microsoft.EntityFrameworkCore;
using MusicPlatform.DataLayer.Models;
using System.Configuration;

namespace MusicPlatform.DataLayer
{
    internal class MusicDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MusicPlatform"].ConnectionString);
        }
    }
}
