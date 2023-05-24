using MusicPlatform.DataLayer.Enums;

namespace MusicPlatform.DataLayer.Models
{
    public class Song : BaseEntity
    {
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public int Likes { get; set; }
        public int Streams { get; set; }

        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
