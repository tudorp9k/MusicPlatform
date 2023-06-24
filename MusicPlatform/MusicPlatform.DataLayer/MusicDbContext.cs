using Microsoft.EntityFrameworkCore;
using MusicPlatform.DataLayer.Models;
using Single = MusicPlatform.DataLayer.Models.Single;

namespace MusicPlatform.DataLayer
{
    public class MusicDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Single> Singles { get; set; }
        public DbSet<EP> EPs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MusicPlatform"].ConnectionString);
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=MusicPlatform; Encrypt=False; Integrated Security=SSPI");
        }
    }
}
