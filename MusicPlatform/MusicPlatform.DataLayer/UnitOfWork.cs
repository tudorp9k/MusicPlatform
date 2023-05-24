using MusicPlatform.DataLayer.Repositories;

namespace MusicPlatform.DataLayer
{
    public class UnitOfWork
    {
        private readonly MusicDbContext dbContext;

        public ArtistRepository Artists { get; }
        public SongRepository Songs { get; }

        public UserRepository Users { get; }

        public UnitOfWork(MusicDbContext dbContext, ArtistRepository artists, SongRepository songs, UserRepository users)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            Artists = artists ?? throw new ArgumentNullException(nameof(artists));
            Songs = songs ?? throw new ArgumentNullException(nameof(songs));
            Users = users ?? throw new ArgumentNullException(nameof(users));
        }

        public void SaveChanges()
        {
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                var errorMessage = "Error when saving to the database: "
                    + $"{exception.Message}\n\n"
                    + $"{exception.InnerException}\n\n"
                    + $"{exception.StackTrace}\n\n";

                Console.WriteLine(errorMessage);
            }
        }
    }
}
