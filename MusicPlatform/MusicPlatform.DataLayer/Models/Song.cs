using MusicPlatform.DataLayer.Enums;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int? AlbumId { get; set; }
        public virtual Album Album { get; set; }

        public int? PlaylistId { get; set; }
        public virtual Playlist Playlist { get; set; }

        [ForeignKey("Single")]
        public int? SingleId { get; set; }
        public virtual Single Single { get; set; }

        public int? EPId { get; set; }
        public virtual EP EP { get; set; }
    }
}
