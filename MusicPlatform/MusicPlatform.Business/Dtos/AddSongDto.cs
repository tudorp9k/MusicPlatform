using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlatform.Business.Dtos
{
    public class AddSongDto
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Likes { get; set; }
        public int Streams { get; set; }
        public int ArtistId { get; set; }
    }
}
