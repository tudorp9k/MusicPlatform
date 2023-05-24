using Microsoft.EntityFrameworkCore;
using MusicPlatform.DataLayer.Models;
using System.Configuration;

namespace MusicPlatform.DataLayer
{
    public class MusicDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MusicPlatform"].ConnectionString);
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=MusicPlatform; Encrypt=False; Integrated Security=SSPI");
        }
    }
}
