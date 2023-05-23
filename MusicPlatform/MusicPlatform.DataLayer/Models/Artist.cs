using MusicPlatform.DataLayer.Enums;

namespace MusicPlatform.DataLayer.Models
{
    internal class Artist : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}
