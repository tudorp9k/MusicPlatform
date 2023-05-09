using MusicPlatform.DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlatform.DataLayer.Models
{
    internal class Song : BaseEntity
    {
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public int Likes { get; set; }
        public int Streams { get; set; }

        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
