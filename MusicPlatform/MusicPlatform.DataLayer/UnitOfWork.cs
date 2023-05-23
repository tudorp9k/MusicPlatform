using MusicPlatform.DataLayer.Repositories;

namespace MusicPlatform.DataLayer
{
    internal class UnitOfWork
    {
        private readonly MusicDbContext dbContext;

        public ArtistRepository Artists { get; }
        public SongRepository Songs { get; }

        public UnitOfWork(MusicDbContext dbContext, ArtistRepository artists, SongRepository songs)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            Artists = artists ?? throw new ArgumentNullException(nameof(artists));
            Songs = songs ?? throw new ArgumentNullException(nameof(songs));
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
