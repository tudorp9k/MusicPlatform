using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlatform.DataLayer.Models
{
    public class Single : BaseEntity
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int? ArtistId { get; set; }
        public virtual Artist Artist { get; set; }

        public int? SongId { get; set; }
        public virtual Song Song { get; set; }
    }
}
